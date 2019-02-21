using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject loadingScreen; //must be setActive False in scene

    private Scene currentLevel;
    private string levelToLoad = null;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;

        if (SceneManager.sceneCount == 1)
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        //Debug.Log($"{scene.name} has been unloaded");
        if (levelToLoad != null)
        {
            SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        SceneManager.SetActiveScene(scene);
        currentLevel = scene;
        levelToLoad = null;
        loadingScreen.SetActive(false);
    }

    public void GoToLevel(string levelName)
    {
        loadingScreen.SetActive(true);
        levelToLoad = levelName;
        SceneManager.UnloadSceneAsync(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
