using UnityEngine;

public class TimedTaskManager : MonoBehaviour
{
    public AdvancedTaskCharacterVR virtualCharacter; // Reference to the character
    public float timeLimit = 30f; // Time limit in seconds
    private float timeRemaining;

    private bool isTaskActive = false;

    private void Update()
    {
        if (isTaskActive)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                TaskFailed();
            }
        }
    }

    public void StartTimedTask()
    {
        timeRemaining = timeLimit;
        isTaskActive = true;
        virtualCharacter.PlayAnimation("Worried");
        Debug.Log("Timed task started!");
    }

    private void TaskFailed()
    {
        isTaskActive = false;
        virtualCharacter.PlayAnimation("Sad");
        virtualCharacter.dialogueManager.StartDialogue(virtualCharacter.characterName, "Time's up! Let's try again.");
        Debug.Log("Task failed.");
    }

    public void CompleteTask()
    {
        isTaskActive = false;
        virtualCharacter.PlayAnimation("Happy");
        virtualCharacter.dialogueManager.StartDialogue(virtualCharacter.characterName, "Well done! You completed the task in time.");
        Debug.Log("Task completed successfully.");
    }
}