using UnityEngine;

public class ActiveTaskTrigger : MonoBehaviour
{
    public AdvancedTaskCharacterVR taskCharacter; // Reference to the main character
    public float taskTriggerInterval = 30f; // Time interval between automatic tasks
    private float timeSinceLastTask;

    private void Update()
    {
        timeSinceLastTask += Time.deltaTime;

        if (timeSinceLastTask >= taskTriggerInterval)
        {
            TriggerTask();
            timeSinceLastTask = 0f;
        }
    }

    private void TriggerTask()
    {
        string randomTask = GenerateRandomTask();
        taskCharacter.taskSteps.Add(randomTask);
        taskCharacter.dialogueManager.StartDialogue(taskCharacter.characterName, $"Here's a new task: {randomTask}");
        Debug.Log($"New task triggered: {randomTask}");
    }

    private string GenerateRandomTask()
    {
        string[] tasks = {
            "Find the ancient artifact in the hidden cave.",
            "Bring me the glowing crystal from the mountain.",
            "Collect 5 mystical herbs from the forest."
        };

        return tasks[Random.Range(0, tasks.Length)];
    }
}