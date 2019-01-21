using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button button;

    public void OnClick()
    {
        button.interactable = false;
        Managers.Instance.levelManager.GoToLevel("MainScene");
    }
}