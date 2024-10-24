using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField]
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button upgradeButton;
    [SerializeField] 
    private GameObject upgradePanel;

    [Space(13)]
    
    [SerializeField] 
    private Button nextButton;
    [SerializeField]
    private Button previousButton;
    [SerializeField] 
    private GameObject[] character;

    private int currentIndex;
    private int maxIndex = 3;

    private void OnEnable()
    {
        currentIndex = 0;
        SetActiveCharacter();
    }

    private void Awake()
    {
        CharacterShopButtonClickAction();
    }

    private void CharacterShopButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                upgradePanel.SetActive(true);
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

    private void SetActiveCharacter()
    {
        for (int i = 0; i < character.Length; i++)
        {
            if (i == currentIndex)
            {
                character[i].SetActive(true);
            }
            else
            {
                character[i].SetActive(false);
            }
        }
    }

    private void Next()
    {
        currentIndex++;

        if (currentIndex > maxIndex)
        {
            currentIndex = 0;
            SetActiveCharacter();
        }
        else
        {
            SetActiveCharacter();
        }
    }

    private void Previous()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = maxIndex;
            SetActiveCharacter();
        }
        else
        {
            SetActiveCharacter();
        }
    }
}
