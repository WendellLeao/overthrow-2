[System.Serializable]
public sealed class GameData
{
    public int currentSceneIndex;

    public void Reset()
    {
        int skippedScenesAmount = SceneHandler.GetActiveSceneIndex() + 2;//Main Menu and LoadingScreen
        currentSceneIndex = skippedScenesAmount;
    }
}