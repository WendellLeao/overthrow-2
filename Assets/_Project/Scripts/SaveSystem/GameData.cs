[System.Serializable]
public sealed class GameData
{
    private static GameData _instance;

    public static GameData Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameData();
            }

            return _instance;
        }
        set
        {
            if(value != null)
            {
                _instance = value;
            }
        }
    }

    public int currentLevelIndex;

    public void Reset()
    {
        currentLevelIndex = 0;
    }
}