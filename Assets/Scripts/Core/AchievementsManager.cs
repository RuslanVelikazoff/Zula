using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    private LevelType levelType;
    private int currentLevelIndex;

    private void Start()
    {
        levelType = GameManager.Instance.GetLevelType();
        currentLevelIndex = GameManager.Instance.GetLevelIndex();
    }

    public void IsAchievementComplete()
    {
        CheckCompleteAchievementFirst();
        CheckCompleteAchievementNewbie();
        CheckCompleteAchievementTrap();
        CheckAchievementElusive();
        CheckAchievementChampion();
    }

    private void CheckCompleteAchievementFirst()
    {
        if (PlayerPrefs.GetInt("LevelCompleteTry") == 0)
        {
            AchievementsData.Instance.CompleteAchievement(levelType, 0);
        }
    }

    private void CheckCompleteAchievementNewbie()
    {
        if (currentLevelIndex == 2)
        {
            AchievementsData.Instance.CompleteAchievement(levelType, 1);
        }
    }

    private void CheckCompleteAchievementTrap()
    {
        if (TimerManager.Instance.GetMinute() < 1)
        {
            AchievementsData.Instance.CompleteAchievement(levelType, 2);
        }
    }

    private void CheckAchievementElusive()
    {
        if (PlayerHealth.Instance.GetPlayerHealth() == 60)
        {
            AchievementsData.Instance.CompleteAchievement(levelType, 3);
        }
    }

    private void CheckAchievementChampion()
    {
        if (currentLevelIndex == 5)
        {
            AchievementsData.Instance.CompleteAchievement(levelType, 4);
        }
    }
}
