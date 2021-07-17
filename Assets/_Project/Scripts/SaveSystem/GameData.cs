using UnityEngine;

[System.Serializable]
public sealed class GameData
{
    public int CurrentSceneIndex;
    
    public int QualitySettingsIndex;

    public int CurrentDropdownResolutionIndex;

    public int CurrentResolutionWidth, CurrentResolutionHeight;

    public float AudioMixerValue;
    
    public bool IsFullscreen;
    
    public void ResetAllData()
    {
        ResetCurrentSceneIndex();
        ResetAudioMixerValue();
        ResetQualitySettings();
    }
    
    public void ResetCurrentSceneIndex()
    {
        int skippedScenesAmount = SceneHandler.GetActiveSceneIndex() + 1;
        CurrentSceneIndex = skippedScenesAmount;
    }

    public void ResetAudioMixerValue()
    {
        AudioMixerValue = 1f;
    }
    
    public void ResetQualitySettings()
    {
        QualitySettingsIndex = 0;

        CurrentResolutionWidth = Screen.currentResolution.width;
        CurrentResolutionHeight = Screen.currentResolution.height;
        
        IsFullscreen = true;
    }
}