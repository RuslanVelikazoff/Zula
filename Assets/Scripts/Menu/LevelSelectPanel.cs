using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectPanel : MonoBehaviour
{
    [SerializeField] 
    private LevelType levelType;

    [Space(13)]
    
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI moneyText;

    [Space(13)]
    
    [SerializeField]
    private Button[] levelButton;
    [SerializeField] 
    private TextMeshProUGUI[] levelText;
    [SerializeField]
    private GameObject[] lockLevel;
    private bool[] unlockLevel = new bool[6];

    [Space(13)]    
    
    [SerializeField]
    private Color unlockColor;
    [SerializeField] 
    private Color lockColor;

    private void OnEnable()
    {
        moneyText.text = MoneyData.Instance.GetMoneyAmount().ToString();
        SetUnlockLevel();
    }

    private void Awake()
    {
        LevelSelectButtonClickAction();
    }

    private void LevelSelectButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (levelButton[0] != null)
        {
            levelButton[0].onClick.AddListener(() =>
            {
                StartLevel(0);
            });
        }
        
        if (levelButton[1] != null)
        {
            levelButton[1].onClick.AddListener(() =>
            {
                StartLevel(1);
            });
        }
        
        if (levelButton[2] != null)
        {
            levelButton[2].onClick.AddListener(() =>
            {
                StartLevel(2);
            });
        }
        
        if (levelButton[3] != null)
        {
            levelButton[3].onClick.AddListener(() =>
            {
                StartLevel(3);
            });
        }
        
        if (levelButton[4] != null)
        {
            levelButton[4].onClick.AddListener(() =>
            {
                StartLevel(4);
            });
        }
        
        if (levelButton[5] != null)
        {
            levelButton[5].onClick.AddListener(() =>
            {
                StartLevel(5);
            });
        }
    }

    private void StartLevel(int levelIndex)
    {
        if (unlockLevel[levelIndex])
        {
            Loader.Load(levelType.ToString() + "Level" + (levelIndex + 1));
        }
    }

    private void SetUnlockLevel()
    {
        switch (levelType)
        {
            case LevelType.Green:
                for (int i = 0; i < unlockLevel.Length; i++)
                {
                    unlockLevel[i] = LevelData.Instance.GetOpenGreenLevel(i);

                    if (unlockLevel[i])
                    {
                        levelText[i].color = unlockColor;
                        lockLevel[i].SetActive(false);
                    }
                    else
                    {
                        levelText[i].color = lockColor;
                        lockLevel[i].SetActive(true);
                    }
                }
                break;
            
            case LevelType.Pink:
                for (int i = 0; i < unlockLevel.Length; i++)
                {
                    unlockLevel[i] = LevelData.Instance.GetOpenPinkLevel(i);

                    if (unlockLevel[i])
                    {
                        levelText[i].color = unlockColor;
                        lockLevel[i].SetActive(false);
                    }
                    else
                    {
                        levelText[i].color = lockColor;
                        lockLevel[i].SetActive(true);
                    }
                }
                break;
            
            case LevelType.Blue:
                for (int i = 0; i < unlockLevel.Length; i++)
                {
                    unlockLevel[i] = LevelData.Instance.GetOpenBlueLevel(i);

                    if (unlockLevel[i])
                    {
                        levelText[i].color = unlockColor;
                        lockLevel[i].SetActive(false);
                    }
                    else
                    {
                        levelText[i].color = lockColor;
                        lockLevel[i].SetActive(true);
                    }
                }
                break;
        }
    }
}
