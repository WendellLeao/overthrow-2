[System.Serializable]
public sealed class GameData
{
    public int currentSceneIndex;

    public float audioMixerValue;

    public void ResetCurrentSceneIndex()
    {
        int skippedScenesAmount = SceneHandler.GetActiveSceneIndex() + 1;
        currentSceneIndex = skippedScenesAmount;
    }

    public void ResetAudioMixerValue()
    {
        audioMixerValue = 1f;
    }
}