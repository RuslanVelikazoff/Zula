using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    [SerializeField] 
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button[] languageButton;
    [SerializeField] 
    private TextMeshProUGUI[] languageText;
    [SerializeField] 
    private Color selectedColor;
    [SerializeField] 
    private Color unselectedColor;
    private int selectedLanguage;

    [Space(13)]
    
    [SerializeField] 
    private Button rateUsButton;
    [SerializeField] 
    private Button bugReportButton;
    [SerializeField] 
    private string rateUsURL;
    [SerializeField]
    private string bugReportURL;

    [Space(13)]
    
    [SerializeField] 
    private Slider soundSlider;
    [SerializeField] 
    private Slider musicSlider;

    private void OnEnable()
    {
        selectedLanguage = PlayerPrefs.GetInt("SelectedLanguage", 0);
        SetLanguageButton();

        soundSlider.value = AudioManager.Instance.GetSoundVolume();
        musicSlider.value = AudioManager.Instance.GetMusicVolume();
    }

    private void Awake()
    {
        SettingsButtonClickAction();
    }

    private void SettingsButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (languageButton[0] != null)
        {
            languageButton[0].onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("SelectedLanguage", 0);
                selectedLanguage = PlayerPrefs.GetInt("SelectedLanguage", 0);
                SetLanguageButton();
            });
        }
        
        if (languageButton[1] != null)
        {
            languageButton[1].onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("SelectedLanguage", 1);
                selectedLanguage = PlayerPrefs.GetInt("SelectedLanguage", 0);
                SetLanguageButton();
            });
        }
        
        if (languageButton[2] != null)
        {
            languageButton[2].onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("SelectedLanguage", 2);
                selectedLanguage = PlayerPrefs.GetInt("SelectedLanguage", 0);
                SetLanguageButton();
            });
        }

        if (rateUsButton != null)
        {
            rateUsButton.onClick.AddListener(() =>
            {
                Application.OpenURL(rateUsURL);
            });
        }

        if (bugReportButton != null)
        {
            bugReportButton.onClick.AddListener(() =>
            {
                Application.OpenURL(bugReportURL);
            });
        }
    }

    private void SetLanguageButton()
    {
        for (int i = 0; i < languageButton.Length; i++)
        {
            if (i == selectedLanguage)
            {
                languageButton[i].GetComponent<Image>().color = selectedColor;
                languageText[i].color = selectedColor;
            }
            else
            {
                languageButton[i].GetComponent<Image>().color = unselectedColor;
                languageText[i].color = unselectedColor;
            }
        }
    }

    public void SoundSlider()
    {
        AudioManager.Instance.SetSoundVolume(soundSlider.value);
    }

    public void MusicSlider()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
    }
}
