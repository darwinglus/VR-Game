using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public string description;
    public bool isCompleted = false;
    public List<string> objectives = new List<string>();
    public string reward;

    public void CompleteQuest()
    {
        isCompleted = true;
        Debug.Log($"Quest '{questName}' completed! Reward: {reward}");
    }
}

public class QuestSystem : MonoBehaviour
{
    public List<Quest> activeQuests = new List<Quest>();

    public void AddQuest(Quest newQuest)
    {
        activeQuests.Add(newQuest);
        Debug.Log($"New quest added: {newQuest.questName}");
    }

    public void CompleteObjective(string questName, string objective)
    {
        Quest quest = activeQuests.Find(q => q.questName == questName);
        if (quest != null && quest.objectives.Contains(objective))
        {
            quest.objectives.Remove(objective);
            Debug.Log($"Objective '{objective}' completed for quest '{questName}'");
            if (quest.objectives.Count == 0)
                quest.CompleteQuest();
        }
    }

    public void ListQuests()
    {
        foreach (var quest in activeQuests)
        {
            Debug.Log($"Quest: {quest.questName}, Completed: {quest.isCompleted}");
        }
    }
}