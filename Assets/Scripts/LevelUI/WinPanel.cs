using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private TextMeshProUGUI goalText;

    [Space(13)]
    
    [SerializeField] 
    private Button homeButton;
    [SerializeField]
    private Button restartButton;

    private void OnEnable()
    {
        SetWinTexts();
        WinButtonClickAction();
    }

    private void WinButtonClickAction()
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

    private void SetWinTexts()
    {
        moneyText.text = $"+{MoneyManager.Instance.GetMoneyAmount().ToString()}";
        timerText.text = TimerManager.Instance.GetTimerText();
        goalText.text = GoalManager.Instance.GetGoalText();
    }
}
