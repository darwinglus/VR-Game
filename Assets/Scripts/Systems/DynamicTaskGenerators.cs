using UnityEngine;

public class DynamicTaskGenerator : MonoBehaviour
{
    public string[] taskDescriptions;
    public Transform[] taskLocations;

    public string GenerateTask()
    {
        int randomIndex = Random.Range(0, taskDescriptions.Length);
        Transform randomLocation = taskLocations[Random.Range(0, taskLocations.Length)];
        Debug.Log($"Generated task: {taskDescriptions[randomIndex]} at location {randomLocation.name}");
        return taskDescriptions[randomIndex];
    }
}