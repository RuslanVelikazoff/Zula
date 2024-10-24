using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField]
    private Button characterButton;
    [SerializeField]
    private GameObject characterPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button buyLightingButton;
    [SerializeField]
    private Button buyFreezeButton;
    [SerializeField] 
    private Button buyProtectionButton;
    [SerializeField]
    private GameObject[] priceGameObject;

    private int money;
    private int[] price = new int[] {400, 500, 600};

    private void OnEnable()
    {
        SetActiveUpgrades();
        SetMoney();
    }

    private void Awake()
    {
        UpgradeButtonClickAction();
    }

    private void UpgradeButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (characterButton != null)
        {
            characterButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                characterPanel.SetActive(true);
            });
        }

        if (buyLightingButton != null)
        {
            buyLightingButton.onClick.AddListener(() =>
            {
                if (money >= price[0])
                {
                    MoneyData.Instance.MinusMoney(price[0]);
                    ShopData.Instance.BuyLighting();
                    SetMoney();
                    SetActiveUpgrades();
                }
            });
        }

        if (buyFreezeButton != null)
        {
            buyFreezeButton.onClick.AddListener(() =>
            {
                if (money >= price[1])
                {
                    MoneyData.Instance.MinusMoney(price[1]);
                    ShopData.Instance.BuyFreeze();
                    SetMoney();
                    SetActiveUpgrades();
                }
            });
        }

        if (buyProtectionButton != null)
        {
            buyProtectionButton.onClick.AddListener(() =>
            {
                if (money >= price[2])
                {
                    MoneyData.Instance.MinusMoney(price[2]);
                    ShopData.Instance.BuyProtection();
                    SetMoney();
                    SetActiveUpgrades();
                }
            });
        }
    }

    private void SetMoney()
    {
        money = MoneyData.Instance.GetMoneyAmount();
    }

    private void SetActiveUpgrades()
    {
        if (ShopData.Instance.GetPurchasedLighting())
        {
            buyLightingButton.gameObject.SetActive(false);
            priceGameObject[0].SetActive(false);
        }
        else
        {
            buyLightingButton.gameObject.SetActive(true);
            priceGameObject[0].SetActive(true);
        }

        if (ShopData.Instance.GetPurchasedFreeze())
        {
            buyFreezeButton.gameObject.SetActive(false);
            priceGameObject[1].SetActive(false);
        }
        else
        {
            buyFreezeButton.gameObject.SetActive(true);
            priceGameObject[1].SetActive(true);
        }

        if (ShopData.Instance.GetPurchasedProtection())
        {
            buyProtectionButton.gameObject.SetActive(false);
            priceGameObject[2].SetActive(false);
        }
        else
        {
            buyProtectionButton.gameObject.SetActive(true);
            priceGameObject[2].SetActive(true);
        }
    }
}
