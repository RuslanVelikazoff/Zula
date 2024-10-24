using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    [SerializeField]
    private LevelType levelType;

    [Space(13)]
    
    [SerializeField] 
    private Image[] achievementImage;
    [SerializeField] 
    private Sprite[] unlockSprite;
    [SerializeField]
    private Sprite lockSprite;

    private void OnEnable()
    {
        SetAchievementSprite();
    }

    private void SetAchievementSprite()
    {
        switch (levelType)
        {
            case LevelType.Green:
                for (int i = 0; i < achievementImage.Length; i++)
                {
                    if (AchievementsData.Instance.GetGreenAchievementComplete(i))
                    {
                        achievementImage[i].sprite = unlockSprite[i];
                    }
                    else
                    {
                        achievementImage[i].sprite = lockSprite;
                    }
                }
                break;
            
            case LevelType.Pink:
                for (int i = 0; i < achievementImage.Length; i++)
                {
                    if (AchievementsData.Instance.GetPinkAchievementComplete(i))
                    {
                        achievementImage[i].sprite = unlockSprite[i];
                    }
                    else
                    {
                        achievementImage[i].sprite = lockSprite;
                    }
                }
                break;
            
            case LevelType.Blue:
                for (int i = 0; i < achievementImage.Length; i++)
                {
                    if (AchievementsData.Instance.GetBlueAchievementComplete(i))
                    {
                        achievementImage[i].sprite = unlockSprite[i];
                    }
                    else
                    {
                        achievementImage[i].sprite = lockSprite;
                    }
                }
                break;
        }
    }
}
