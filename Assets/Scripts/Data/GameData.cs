public class GameData
{
    public int money;

    public bool[] openGreenLevel = new bool[6];
    public bool[] completedGreenLevel = new bool[6];
    public bool[] openPinkLevel = new bool[6];
    public bool[] completedPinkLevel = new bool[6];
    public bool[] openBlueLevel = new bool[6];
    public bool[] completedBlueLevel = new bool[6];

    public bool[] greenAchievementComplete = new bool[5];
    public bool[] pinkAchievementComplete = new bool[5];
    public bool[] blueAchievementComplete = new bool[5];
    
    public bool[] purchasedCharacter = new bool[4];
    public bool[] selectedCharacter = new bool[4];
    public bool purchasedLighting = false;
    public bool purchasedFreeze = false;
    public bool purchasedProtection = false;
    
    public GameData()
    {
        money = 0;

        for (int i = 0; i < openGreenLevel.Length; i++)
        {
            if (i == 0)
            {
                openGreenLevel[i] = true;
                completedGreenLevel[i] = false;
            }
            else
            {
                openGreenLevel[i] = false;
                completedGreenLevel[i] = false;
            }
        }

        for (int i = 0; i < openPinkLevel.Length; i++)
        {
            openPinkLevel[i] = false;
            completedPinkLevel[i] = false;
        }

        for (int i = 0; i < openBlueLevel.Length; i++)
        {
            openBlueLevel[i] = false;
            completedBlueLevel[i] = false;
        }

        for (int i = 0; i < greenAchievementComplete.Length; i++)
        {
            greenAchievementComplete[i] = false;
            pinkAchievementComplete[i] = false;
            blueAchievementComplete[i] = false;
        }

        for (int i = 0; i < purchasedCharacter.Length; i++)
        {
            if (i == 0)
            {
                purchasedCharacter[i] = true;
                selectedCharacter[i] = true;
            }
            else
            {
                purchasedCharacter[i] = false;
                selectedCharacter[i] = false;
            }
        }
    }
}
