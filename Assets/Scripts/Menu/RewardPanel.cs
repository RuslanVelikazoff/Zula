using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardPanel : MonoBehaviour
{
    [SerializeField]
    private Button takeButton;
    [SerializeField]
    private Button backButton;
    [SerializeField] 
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField] 
    private RewardPrefab rewardPrefab;
    [SerializeField]
    private Transform rewardsGrid;
    
    [Space(13)]

    [SerializeField] 
    private List<Reward> rewards;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI moneyText;
    [SerializeField] 
    private GameObject moneyGameObject;
    

    private int currentStreak
    {
        get => PlayerPrefs.GetInt("currentStreak", 0);
        set => PlayerPrefs.SetInt("currentStreak", value);
    }

    private DateTime? lastClaimTime
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimedTime", null);

            if (!string.IsNullOrEmpty(data))
            {
                return DateTime.Parse(data);
            }

            return null;
        }
        set
        {
            if (value != null)
            {
                PlayerPrefs.SetString("lastClaimedTime", value.ToString());
            }
            else
            {
                PlayerPrefs.DeleteKey("lastClaimedTime");
            }
        }
    }

    private bool canClaimReward;
    private int maxStreakCount = 8;
    private float claimCooldown = 24f;
    private float claimDeadline = 48f;
    
    private List<RewardPrefab> rewardPrefabs;

    private void Start()
    {
        InitPrefabs();
        StartCoroutine(RewardsStateUpdater());
        RewardButtonClickAction();
    }

    private void RewardButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (takeButton != null)
        {
            takeButton.onClick.AddListener(() =>
            {
                ClaimReward();
            });
        }
    }

    private void InitPrefabs()
    {
        rewardPrefabs = new List<RewardPrefab>();

        for (int i = 0; i < maxStreakCount; i++)
        {
            rewardPrefabs.Add(Instantiate(rewardPrefab, rewardsGrid, false));
        }
    }

    private IEnumerator RewardsStateUpdater()
    {
        while (true)
        {
            UpdateRewardsState();
            yield return new WaitForSeconds(1f);
        }
    }

    private void UpdateRewardsState()
    {
        canClaimReward = true;

        if (lastClaimTime.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTime.Value;

            if (timeSpan.TotalHours > claimDeadline)
            {
                lastClaimTime = null;
                currentStreak = 0;
            }
            
            else if (timeSpan.TotalHours < claimCooldown)
            {
                canClaimReward = false;
            }
        }
        
        UpdateRewardsUI();
    }

    private void UpdateRewardsUI()
    {
        takeButton.interactable = canClaimReward;

        for (int i = 0; i < rewardPrefabs.Count; i++)
        {
            rewardPrefabs[i].SetRewardData(i, currentStreak, rewards[i]);
        }
    }

    private void SetMoneyText()
    {
        moneyGameObject.SetActive(true);
        moneyText.text = MoneyData.Instance.GetMoneyAmount().ToString();
    }

    private void ClaimReward()
    {
        if (!canClaimReward)
        {
            return;
        }
        
        MoneyData.Instance.PlusMoney(rewards[currentStreak].Value);

        lastClaimTime = DateTime.UtcNow;
        currentStreak = (currentStreak + 1) % maxStreakCount;
        
        SetMoneyText();
    }
}
