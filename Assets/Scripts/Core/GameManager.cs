using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject winPanel;
    [SerializeField] 
    private GameObject losePanel;

    [Space(13)]
    
    [SerializeField]
    private LevelType levelType;
    [SerializeField] 
    private int currentLevelIndex;

    [Space(13)]
    
    [SerializeField] 
    private AchievementsManager achievements;

    private void Awake()
    {
        Instance = this;
        PlayerPrefs.GetInt("LevelCompleteTry", 0);
    }

    public void WinGame()
    {
        AudioManager.Instance.Play("Win");
        winPanel.SetActive(true);
        MoneyData.Instance.PlusMoney(MoneyManager.Instance.GetMoneyAmount());
        PlayerPrefs.SetInt("LevelCompleteTry", 0);
        achievements.IsAchievementComplete();
        CompleteLevel();
    }

    public void LoseGame()
    {
        AudioManager.Instance.Play("Lose");
        losePanel.SetActive(true);
        PlayerPrefs.SetInt("LevelCompleteTry", PlayerPrefs.GetInt("LevelCompleteTry") + 1);
        MoneyData.Instance.PlusMoney(MoneyManager.Instance.GetMoneyAmount());
    }

    private void CompleteLevel()
    {
        switch (levelType)
        {
            case LevelType.Green:
                LevelData.Instance.CompleteGreenLevel(currentLevelIndex);
                break;
            
            case LevelType.Pink:
                LevelData.Instance.CompletePinkLevel(currentLevelIndex);
                break;
            
            case LevelType.Blue:
                LevelData.Instance.CompleteBlueLevel(currentLevelIndex);
                break;
        }
    }

    public LevelType GetLevelType()
    {
        return levelType;
    }

    public int GetLevelIndex()
    {
        return currentLevelIndex;
    }
}
