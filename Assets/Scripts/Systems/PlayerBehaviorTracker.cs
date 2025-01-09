using UnityEngine;

public class PlayerBehaviorTracker : MonoBehaviour
{
    private int tasksCompleted = 0;
    private float totalPlayTime = 0f;

    private void Update()
    {
        totalPlayTime += Time.deltaTime;
    }

    public void TaskCompleted()
    {
        tasksCompleted++;
        Debug.Log($"Tasks completed: {tasksCompleted}");
    }

    public void DisplayAnalytics()
    {
        Debug.Log($"Total playtime: {totalPlayTime} seconds");
        Debug.Log($"Total tasks completed: {tasksCompleted}");
    }
}