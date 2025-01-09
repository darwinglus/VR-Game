using UnityEngine;
using System.Collections.Generic;

public class BranchingTaskManager : MonoBehaviour
{
    public AdvancedTaskCharacterVR virtualCharacter; // Reference to the main character
    public DynamicEnvironmentManager environmentManager; // Reference to the environment manager
    public List<string> branchA_Tasks; // Tasks for Branch A
    public List<string> branchB_Tasks; // Tasks for Branch B

    private bool branchASelected = false; // Whether Branch A is chosen
    private bool branchBSelected = false; // Whether Branch B is chosen

    private void Start()
    {
        if (branchA_Tasks.Count == 0 || branchB_Tasks.Count == 0)
        {
            Debug.LogError("Branching tasks are not properly configured!");
        }
    }

    public void SelectBranch(string branch)
    {
        if (branch == "A" && !branchASelected && !branchBSelected)
        {
            branchASelected = true;
            virtualCharacter.taskSteps = new List<string>(branchA_Tasks);
            environmentManager.ChangeEnvironment("Forest"); // Example change
            Debug.Log("Branch A selected. Tasks updated.");
        }
        else if (branch == "B" && !branchBSelected && !branchASelected)
        {
            branchBSelected = true;
            virtualCharacter.taskSteps = new List<string>(branchB_Tasks);
            environmentManager.ChangeEnvironment("Cave"); // Example change
            Debug.Log("Branch B selected. Tasks updated.");
        }
        else
        {
            Debug.LogWarning("Invalid or duplicate branch selection!");
        }
    }
}