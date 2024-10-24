using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField] private int maxHealth;
    private int currentHealth;
    private int damage = 10;

    private bool activeProtection;

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;

        if (PlayerPrefs.GetInt("PurchasedProtection") == 0)
        {
            activeProtection = false;
        }
        else
        {
            StartCoroutine(ActiveProtectionCO());
        }
    }

    public void Damage()
    {
        AudioManager.Instance.Play("Damage");
        if (!activeProtection)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                this.gameObject.SetActive(false);
                GameManager.Instance.LoseGame();
            }
        }
    }

    public int GetPlayerHealth()
    {
        return currentHealth;
    }

    private IEnumerator ActiveProtectionCO()
    {
        activeProtection = true;

        yield return new WaitForSeconds(10);

        activeProtection = false;
    }
}
