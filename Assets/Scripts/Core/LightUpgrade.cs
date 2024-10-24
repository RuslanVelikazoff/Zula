using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LightUpgrade : MonoBehaviour
{
    [SerializeField] private Button lightButton;

    [SerializeField] private Light light;

    private float standartIntensity = .2f;
    private float maxIntensity = 1f;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("PurchasedLighting") == 0)
        {
            lightButton.interactable = false;
            light.intensity = standartIntensity;
        }
        else
        {
            lightButton.interactable = true;
            light.intensity = standartIntensity;
        }
        
        LightButtonClickAction();
    }

    private void LightButtonClickAction()
    {
        if (lightButton != null)
        {
            lightButton.onClick.AddListener(() =>
            {
                LightOn();
            });
        }
    }

    private void LightOn()
    {
        StartCoroutine(LightUpgradeActiveCO());
    }

    private IEnumerator LightUpgradeActiveCO()
    {
        light.intensity = maxIntensity;
        lightButton.interactable = false;

        yield return new WaitForSeconds(10);

        light.intensity = standartIntensity;

        yield return new WaitForSeconds(10);

        lightButton.interactable = true;
    }
}
