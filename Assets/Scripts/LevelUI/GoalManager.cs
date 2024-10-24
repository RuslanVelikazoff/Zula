using TMPro;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public static GoalManager Instance { get; private set; }

    [SerializeField] 
    private TextMeshProUGUI goalText;

    [Space(13)]
    
    [SerializeField] 
    private int needGoal;
    private int collectedGoal;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectedGoal()
    {
        collectedGoal++;
        SetGoalText();

        if (collectedGoal >= needGoal)
        {
            GameManager.Instance.WinGame();
        }
    }

    public string GetGoalText()
    {
        string goalString = $"{collectedGoal}/{needGoal}";
        return goalString;
    }

    private void SetGoalText()
    {
        goalText.text = $"{collectedGoal}/{needGoal}";
    }
}
