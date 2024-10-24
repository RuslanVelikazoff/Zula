using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardPrefab : MonoBehaviour
{
    [SerializeField] 
    private Image background;
    [SerializeField] 
    private Color defaultColor;
    [SerializeField]
    private Color currentStreakColor;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI dayText;
    [SerializeField] 
    private TextMeshProUGUI valueText;

    public void SetRewardData(int day, int currentStreak, Reward reward)
    {
        dayText.text = $"Day {day + 1}";
        valueText.text = reward.Value.ToString();

        if (day == currentStreak)
        {
            background.color = currentStreakColor;
        }
        else
        {
            background.color = defaultColor;
        }
    }
}
