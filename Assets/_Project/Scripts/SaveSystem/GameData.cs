using UnityEngine;

[System.Serializable]
public sealed class GameData
{
    public int CurrentSceneIndex;

    public float AudioMixerValue;
    
    public int QualitySettingsIndex;

    public int StartDropdownResolutionIndex, CurrentDropdownResolutionIndex;

    public int StartResolutionWidth, StartResolutionHeight;
    public int CurrentResolutionWidth, CurrentResolutionHeight;
    
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

        ResetResolution();
        
        IsFullscreen = true;

        Screen.fullScreen = true;
    }

    private void ResetResolution()
    {
        StartResolutionWidth = Screen.currentResolution.width;
        StartResolutionHeight = Screen.currentResolution.height;

        CurrentResolutionWidth = StartResolutionWidth;
        CurrentResolutionHeight = StartResolutionHeight;
        
        CurrentDropdownResolutionIndex = StartDropdownResolutionIndex;
    }
}