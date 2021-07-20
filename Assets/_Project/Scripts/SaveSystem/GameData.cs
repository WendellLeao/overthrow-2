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
    
    /// <summary>
    /// Não acho uma boa tu colocar METODOS dentro do arquivo de Save.
    /// faz mais senttido esses metodos estarem no SaveSystem, afinnal, ELE é que cuida do save.
    /// este script aqui deveria apenas guardar informação. Afinal ele é o GameData :p
    /// 
    /// </summary>
    
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