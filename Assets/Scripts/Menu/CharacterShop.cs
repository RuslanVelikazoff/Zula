using UnityEngine;
using UnityEngine.UI;

public class CharacterShop : MonoBehaviour
{
    [SerializeField] 
    private int characterIndex;
    [SerializeField]
    private int characterPrice;
    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private Button useButton;
    [SerializeField]
    private GameObject buyGameObject;

    private void OnEnable()
    {
        SetCharacterShop();
    }

    private void Awake()
    {
        CharacterButtonClickAction();
    }

    private void CharacterButtonClickAction()
    {
        if (useButton != null)
        {
            useButton.onClick.AddListener(() =>
            {
                ShopData.Instance.SelectCharacter(characterIndex);
                SetCharacterShop();
            });
        }

        if (buyButton != null)
        {
            buyButton.onClick.AddListener(() =>
            {
                if (MoneyData.Instance.GetMoneyAmount() > characterPrice)
                {
                    MoneyData.Instance.MinusMoney(characterPrice);
                    ShopData.Instance.BuyCharacter(characterIndex);
                    SetCharacterShop();
                }
            });
        }
    }

    private void SetCharacterShop()
    {
        if (ShopData.Instance.GetSelectedCharacter(characterIndex))
        {
            useButton.gameObject.SetActive(false);
            buyGameObject.SetActive(false);
        }
        else
        {
            if (ShopData.Instance.GetPurchasedCharacter(characterIndex))
            {
                useButton.gameObject.SetActive(true);
                buyGameObject.SetActive(false);
            }
            else
            {
                useButton.gameObject.SetActive(false);
                buyGameObject.SetActive(true);
            }
        }
    }
}
