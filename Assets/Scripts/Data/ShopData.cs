using UnityEngine;

public class ShopData : MonoBehaviour
{
    private const string SaveKey = "ShopData";
    
    private bool[] _purchasedCharacter;
    private bool[] _selectedCharacter;
    private bool _purchasedLighting;
    private bool _purchasedFreeze;
    private bool _purchasedProtection;

    public static ShopData Instance;

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
        PlayerPrefs.GetInt("PurchasedLighting", 0);
        PlayerPrefs.GetInt("PurchasedFreeze", 0);
        PlayerPrefs.GetInt("PurchasedProtection", 0);
        PlayerPrefs.GetInt("SelectedCharacter", 0);
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
        
        _purchasedCharacter = data.purchasedCharacter;
        _selectedCharacter = data.selectedCharacter;
        _purchasedLighting = data.purchasedLighting;
        _purchasedFreeze = data.purchasedFreeze;
        _purchasedProtection = data.purchasedProtection;
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
            purchasedCharacter = _purchasedCharacter,
            selectedCharacter = _selectedCharacter,
            purchasedLighting = _purchasedLighting,
            purchasedFreeze = _purchasedFreeze,
            purchasedProtection = _purchasedProtection
        };

        return data;
    }

    #region GetMethods

    public bool GetPurchasedCharacter(int index)
    {
        return _purchasedCharacter[index];
    }

    public bool GetSelectedCharacter(int index)
    {
        return _selectedCharacter[index];
    }

    public bool GetPurchasedLighting()
    {
        return _purchasedLighting;
    }

    public bool GetPurchasedFreeze()
    {
        return _purchasedFreeze;
    }

    public bool GetPurchasedProtection()
    {
        return _purchasedProtection;
    }

    #endregion

    #region SetMethods

    public void BuyCharacter(int index)
    {
        _purchasedCharacter[index] = true;
        SelectCharacter(index);
    }

    public void BuyLighting()
    {
        _purchasedLighting = true;
        PlayerPrefs.SetInt("PurchasedLighting", 1);
        Save();
    }

    public void BuyFreeze()
    {
        _purchasedFreeze = true;
        PlayerPrefs.SetInt("PurchasedFreeze", 1);
        Save();
    }

    public void BuyProtection()
    {
        _purchasedProtection = true;
        PlayerPrefs.SetInt("PurchasedProtection", 1);
        Save();
    }

    public void SelectCharacter(int index)
    {
        for (int i = 0; i < _selectedCharacter.Length; i++)
        {
            if (i == index)
            {
                _selectedCharacter[i] = true;
                PlayerPrefs.SetInt("SelectedCharacter", i);
            }
            else
            {
                _selectedCharacter[i] = false;
            }
        }
        
        Save();
    }

    #endregion
}
