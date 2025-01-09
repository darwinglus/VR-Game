using UnityEngine;

public class StartupManager : MonoBehaviour
{
    public GameSettings gameSettings;
    public NetworkConfig networkConfig;
    public PlayerSettings playerSettings;

    private void Awake()
    {
        Debug.Log("Initializing Game...");
        gameSettings.ApplySettings();
        networkConfig.PrintConfig();
    }

    private void Start()
    {
        Debug.Log($"Player Name: {playerSettings.playerName}");
    }
}