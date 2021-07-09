[System.Serializable]
public sealed class GameData
{
    public int currentLevelIndex;

    public void Reset()
    {
        currentLevelIndex = 0;
    }
}