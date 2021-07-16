using UnityEngine;

[System.Serializable]
public sealed class GameData
{
    public int currentSceneIndex;

    public float audioMixerValue;
    
    public int qualitySettingsIndex;

    public bool isGameFullscreen;


    public void ResetAllData()
    {
        ResetCurrentSceneIndex();
        ResetAudioMixerValue();
        ResetQualitySettings();
    }
    
    public void ResetCurrentSceneIndex()
    {
        int skippedScenesAmount = SceneHandler.GetActiveSceneIndex() + 1;
        currentSceneIndex = skippedScenesAmount;
    }

    public void ResetAudioMixerValue()
    {
        audioMixerValue = 1f;
    }
    
    public void ResetQualitySettings()
    {
        qualitySettingsIndex = QualitySettings.GetQualityLevel();

        isGameFullscreen = true;
    }
}