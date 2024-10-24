using UnityEngine;

public class MoneyData : MonoBehaviour
{
    private const string SaveKey = "MoneyData";

    private int _money;

    public static MoneyData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);

        _money = data.money;
    }

    private void Save()
    {
        SaveManager.Save(SaveKey,GetSaveSnapshot());
        PlayerPrefs.Save();
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            money = _money
        };

        return data;
    }

    public int GetMoneyAmount()
    {
        return _money;
    }

    public void MinusMoney(int amount)
    {
        _money -= amount;
        Save();
    }

    public void PlusMoney(int amount)
    {
        _money += amount;
        Save();
    }
}
