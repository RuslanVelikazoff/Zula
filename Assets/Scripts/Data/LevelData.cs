using UnityEngine;

public class LevelData : MonoBehaviour
{
    private const string SaveKey = "LevelData";

    private bool[] _openGreenLevel;
    private bool[] _completedGreenLevel;
    private bool[] _openPinkLevel;
    private bool[] _completedPinkLevel;
    private bool[] _openBlueLevel;
    private bool[] _completedBlueLevel;

    public static LevelData Instance;

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

        _openGreenLevel = data.openGreenLevel;
        _completedGreenLevel = data.completedGreenLevel;
        _openPinkLevel = data.openPinkLevel;
        _completedPinkLevel = data.completedPinkLevel;
        _openBlueLevel = data.openBlueLevel;
        _completedBlueLevel = data.completedBlueLevel;
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
            openGreenLevel = _openGreenLevel,
            completedGreenLevel = _completedGreenLevel,
            openPinkLevel = _openPinkLevel,
            completedPinkLevel = _completedPinkLevel,
            openBlueLevel = _openBlueLevel,
            completedBlueLevel = _completedBlueLevel
        };

        return data;
    }

    #region GetMethods

    public bool GetOpenGreenLevel(int index)
    {
        return _openGreenLevel[index];
    }

    public bool GetOpenPinkLevel(int index)
    {
        return _openPinkLevel[index];
    }

    public bool GetOpenBlueLevel(int index)
    {
        return _openBlueLevel[index];
    }

    public bool GetCompleteGreenLevel(int index)
    {
        return _completedGreenLevel[index];
    }

    public bool GetCompletePinkLevel(int index)
    {
        return _completedPinkLevel[index];
    }

    public bool GetCompleteBlueLevel(int index)
    {
        return _completedPinkLevel[index];
    }

    #endregion

    #region SetMethods

    public void CompleteGreenLevel(int index)
    {
        _completedGreenLevel[index] = true;
        if (index == _completedGreenLevel.Length - 1)
        {
            _openPinkLevel[0] = true;
        }
        Save();
    }

    public void CompletePinkLevel(int index)
    {
        _completedPinkLevel[index] = true;
        if (index == _completedPinkLevel.Length - 1)
        {
            _openBlueLevel[0] = true;
        }
        Save();
    }

    public void CompleteBlueLevel(int index)
    {
        _completedBlueLevel[index] = true;
        Save();
    }

    #endregion
}
