using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
	public bool horizontalMode = true;
	public bool inverseY = false;

	public static SettingsManager Instance;

	int score = 0;

	private void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Debug.Log("coucou)");
			SceneManager.LoadSceneAsync(0);

		}
	}

	public void ToggleHorizontalMode()
	{
		horizontalMode = !horizontalMode;
	}

	public void ToggleInverseY()
	{
		inverseY = !inverseY;
	}

	public void StartGame(Button button)
	{
		button.interactable = false;
		SceneManager.LoadSceneAsync(1);
	}

	public void Score(int s)
	{
		score += s;
	}
}
