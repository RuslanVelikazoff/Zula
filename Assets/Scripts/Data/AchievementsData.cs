using UnityEngine;

public class AchievementsData : MonoBehaviour
{
    private const string SaveKey = "AchievementsData";

    private bool[] _greenAchievementComplete;
    private bool[] _pinkAchievementComplete;
    private bool[] _blueAchievementComplete;

    public static AchievementsData Instance;

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

        _greenAchievementComplete = data.greenAchievementComplete;
        _pinkAchievementComplete = data.pinkAchievementComplete;
        _blueAchievementComplete = data.blueAchievementComplete;
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
            greenAchievementComplete = _greenAchievementComplete,
            pinkAchievementComplete = _pinkAchievementComplete,
            blueAchievementComplete = _blueAchievementComplete
        };

        return data;
    }

    #region GetMethods

    public bool GetGreenAchievementComplete(int index)
    {
        return _greenAchievementComplete[index];
    }

    public bool GetPinkAchievementComplete(int index)
    {
        return _pinkAchievementComplete[index];
    }

    public bool GetBlueAchievementComplete(int index)
    {
        return _blueAchievementComplete[index];
    }

    #endregion

    public void CompleteAchievement(LevelType levelType, int index)
    {
        switch (levelType)
        {
            case LevelType.Green:
                _greenAchievementComplete[index] = true;
                break;
            
            case LevelType.Pink:
                _pinkAchievementComplete[index] = true;
                break;
            
            case LevelType.Blue:
                _blueAchievementComplete[index] = true;
                break;
        }
    }
}
