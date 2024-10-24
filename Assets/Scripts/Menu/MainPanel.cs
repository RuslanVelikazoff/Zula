using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] 
    private Button shopButton;
    [SerializeField]
    private Button achievementsButton;
    [SerializeField]
    private Button settingsButton;

    [Space(13)]
    
    [SerializeField]
    private GameObject shopPanel;
    [SerializeField]
    private GameObject achievementsPanel;
    [SerializeField] 
    private GameObject settingsPanel;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI levelNameText;
    [SerializeField]
    private GameObject[] selectedLevelSprite;
    [SerializeField] 
    private Button nextButton;
    [SerializeField] 
    private Button previousButton;
    
    [Space(13)]
    
    [SerializeField] 
    private Button playButton;
    [SerializeField]
    private GameObject[] selectLevelPanel;

    private int selectedLevel = 0;
    private int maxLevel = 2;
    private string[] levelName = new string[] {"Green", "Pink", "Blue"};

    private void OnEnable()
    {
        SetLevel();
    }

    private void Awake()
    {
        MainButtonClickAction();
    }

    private void MainButtonClickAction()
    {
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(() =>
            {
                NextLevel();
            });
        }

        if (previousButton != null)
        {
            previousButton.onClick.AddListener(() =>
            {
                PreviousLevel();
            });
        }

        if (shopButton != null)
        {
            shopButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                shopPanel.SetActive(true);
            });
        }

        if (achievementsButton != null)
        {
            achievementsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                achievementsPanel.SetActive(true);
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                settingsPanel.SetActive(true);
            });
        }

        if (playButton != null)
        {
            playButton.onClick.AddListener(() =>
            {
                OpenSelectedLevelPanel();
            });
        }
    }

    private void SetLevel()
    {
        for (int i = 0; i < selectedLevelSprite.Length; i++)
        {
            if (i == selectedLevel)
            {
                levelNameText.text = levelName[i];
                selectedLevelSprite[i].SetActive(true);
            }
            else
            {
                selectedLevelSprite[i].SetActive(false);
            }
        }
    }

    private void NextLevel()
    {
        selectedLevel++;
        
        if (selectedLevel > maxLevel)
        {
            selectedLevel = 0;
            SetLevel();
        }
        else
        {
            SetLevel();
        }
    }

    private void PreviousLevel()
    {
        selectedLevel--;

        if (selectedLevel < 0)
        {
            selectedLevel = maxLevel;
            SetLevel();
        }
        else
        {
            SetLevel();
        }
    }

    private void OpenSelectedLevelPanel()
    {
        for (int i = 0; i < selectLevelPanel.Length; i++)
        {
            if (i == selectedLevel)
            {
                this.gameObject.SetActive(false);
                selectLevelPanel[i].SetActive(true);
            }
            else
            {
                selectLevelPanel[i].SetActive(false);
            }
        }
    }
}
