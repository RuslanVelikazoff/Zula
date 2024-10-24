using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI timerText;
    [SerializeField] 
    private TextMeshProUGUI goalText;

    [Space(13)]
    
    [SerializeField]
    private Button homeButton;
    [SerializeField] 
    private Button restartButton;

    private void Awake()
    {
        LoseButtonClickAction();
        SetTexts();
    }

    private void LoseButtonClickAction()
    {
        if (homeButton != null)
        {
            homeButton.onClick.AddListener(() =>
            {
                Loader.Load("MainMenu");
            });
        }

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(() =>
            {
                Loader.Load(Loader.targetScene);
            });
        }
    }

    private void SetTexts()
    {
        timerText.text = TimerManager.Instance.GetTimerText();
        goalText.text = GoalManager.Instance.GetGoalText();
    }
}
