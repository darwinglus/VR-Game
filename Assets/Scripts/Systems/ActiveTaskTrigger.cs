using UnityEngine;

public class ActiveTaskTrigger : MonoBehaviour
{
    [Header("Task Settings")]
    [Tooltip("Reference to the main character managing tasks.")]
    [SerializeField] private AdvancedTaskCharacterVR taskCharacter;

    [Tooltip("Time interval (in seconds) between triggering automatic tasks.")]
    [SerializeField] private float taskTriggerInterval = 30f;

    private float timeSinceLastTask;

    [Header("Available Tasks")]
    [Tooltip("List of tasks that can be randomly assigned.")]
    [SerializeField] private string[] tasks = {
        "Find the ancient artifact in the hidden cave.",
        "Bring me the glowing crystal from the mountain.",
        "Collect 5 mystical herbs from the forest."
    };

    private void Update()
    {
        timeSinceLastTask += Time.deltaTime;

        if (timeSinceLastTask >= taskTriggerInterval)
        {
            TriggerTask();
            timeSinceLastTask = 0f;
        }
    }

    /// <summary>
    /// Triggers a new task and assigns it to the task character.
    /// </summary>
    private void TriggerTask()
    {
        if (taskCharacter == null)
        {
            Debug.LogError("[ActiveTaskTrigger] Task character reference is missing!");
            return;
        }

        if (tasks.Length == 0)
        {
            Debug.LogWarning("[ActiveTaskTrigger] No tasks available to assign.");
            return;
        }

        string randomTask = GenerateRandomTask();
        taskCharacter.taskSteps.Add(randomTask);

        taskCharacter.dialogueManager.StartDialogue(
            taskCharacter.characterName,
            $"Here's a new task: {randomTask}"
        );

        Debug.Log($"[ActiveTaskTrigger] New task triggered: {randomTask}");
    }

    /// <summary>
    /// Generates a random task from the available task list.
    /// </summary>
    /// <returns>A randomly selected task as a string.</returns>
    private string GenerateRandomTask()
    {
        return tasks[Random.Range(0, tasks.Length)];
    }
}
