using UnityEngine;
using UnityEngine.UI;

public class AchievementsPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button nextButton;
    [SerializeField]
    private Button previousButton;
    [SerializeField] 
    private Image levelTypeImage;
    [SerializeField] 
    private Sprite[] levelTypeSprite;
    [SerializeField]
    private GameObject[] achievementPanel;

    private int currentIndex;
    private int maxIndex = 2;

    private void OnEnable()
    {
        currentIndex = 0;
        
        SetActivePanel();
    }

    private void Awake()
    {
        AchievementsButtonClickAction();
    }

    private void AchievementsButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            { 
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(() =>
            {
                Next();
            });
        }

        if (previousButton != null)
        {
            previousButton.onClick.AddListener(() =>
            {
                Previous();
            });
        }
    }

    private void SetActivePanel()
    {
        for (int i = 0; i < achievementPanel.Length; i++)
        {
            if (i == currentIndex)
            {
                achievementPanel[i].SetActive(true);
                levelTypeImage.sprite = levelTypeSprite[i];
            }
            else
            {
                achievementPanel[i].SetActive(false);
            }
        }
    }

    private void Next()
    {
        currentIndex++;

        if (currentIndex > maxIndex)
        {
            currentIndex = 0;
            SetActivePanel();
        }
        else
        {
            SetActivePanel();
        }
    }

    private void Previous()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = maxIndex;
            SetActivePanel();
        }
        else
        {
            SetActivePanel();
        }
    }
}
