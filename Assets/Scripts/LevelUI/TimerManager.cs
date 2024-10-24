using System.Collections;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }

    [SerializeField] 
    private TextMeshProUGUI timerText;

    private int minutes;
    private float seconds;

    private bool activeFreezeTimer = false;

    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.GetInt("PurchasedFreeze") == 0)
        {
            activeFreezeTimer = false;
        }
        else
        {
            StartCoroutine(FreezeTimerCO());
        }
    }

    private void Update()
    {
        if (!activeFreezeTimer)
        {
            seconds += Time.deltaTime;

            if (seconds >= 60)
            {
                seconds -= 60;
                minutes++;
            }
            
            SetTimerText();
        }
    }

    private void SetTimerText()
    {
        if (seconds < 10)
        {
            timerText.text = $"{minutes}:0{(int) seconds}";
        }
        else
        {
            timerText.text = $"{minutes}:{(int) seconds}";
        }
    }

    public string GetTimerText()
    {
        string timerString = timerText.text;
        return timerString;
    }

    public int GetMinute()
    {
        return minutes;
    }

    private IEnumerator FreezeTimerCO()
    {
        activeFreezeTimer = true;

        yield return new WaitForSeconds(10);

        activeFreezeTimer = false;
    }
}
