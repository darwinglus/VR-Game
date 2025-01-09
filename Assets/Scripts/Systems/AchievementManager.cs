using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string title;
    public string description;
    public bool isUnlocked;
}

public class AchievementManager : MonoBehaviour
{
    public Achievement[] achievements;

    public void UnlockAchievement(string title)
    {
        foreach (var achievement in achievements)
        {
            if (achievement.title == title && !achievement.isUnlocked)
            {
                achievement.isUnlocked = true;
                Debug.Log($"Achievement unlocked: {title}");
                GrantReward(title);
            }
        }
    }

    private void GrantReward(string achievementTitle)
    {
        Debug.Log($"Reward granted for achievement: {achievementTitle}");
        // Implement reward logic here
    }
}