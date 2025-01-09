using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public int tasksCompleted;
    public Vector3 playerPosition;
}

public class PlayerDataManager : MonoBehaviour
{
    private string dataPath;

    private void Start()
    {
        dataPath = Application.persistentDataPath + "/playerData.json";
    }

    public void SavePlayerData(int tasksCompleted, Vector3 playerPosition)
    {
        PlayerData data = new PlayerData
        {
            tasksCompleted = tasksCompleted,
            playerPosition = playerPosition
        };

        File.WriteAllText(dataPath, JsonUtility.ToJson(data));
        Debug.Log("Player data saved.");
    }

    public PlayerData LoadPlayerData()
    {
        if (File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Player data loaded.");
            return data;
        }

        Debug.LogWarning("No saved data found.");
        return null;
    }
}