using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers Instance;

    Managers()
    {
        Instance = this;
    }

    [Header("References")]
    public SettingsManager settingsManager;
}