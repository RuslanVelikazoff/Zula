using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI moneyText;

    private int collectedMoney = 0;

    private void Awake()
    {
        Instance = this;
        SetMoneyText();
    }

    private void SetMoneyText()
    {
        moneyText.text = collectedMoney.ToString();
    }

    public void CollectMoney()
    {
        AudioManager.Instance.Play("Money");
        int amount = Random.Range(1, 20);
        collectedMoney += amount;
        SetMoneyText();
    }

    public int GetMoneyAmount()
    {
        return collectedMoney;
    }
}
