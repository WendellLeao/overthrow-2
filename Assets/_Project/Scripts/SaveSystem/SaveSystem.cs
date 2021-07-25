using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string _fileName = "gameData.json";

    private static GameData _localData = new GameData();

    public static GameData SaveGameData()
    {
        string _json = JsonUtility.ToJson(_localData);

        File.WriteAllText(GetFilePath(), _json);

        return _localData;
    }

    public static GameData LoadGameData()
    {
        string path = GetFilePath();

        if(!SaveFileExists())
        {
            ResetAllData();
            
            return SaveGameData(); //Create a new save file
        }
        else
        {
            string _json = File.ReadAllText(GetFilePath());

            _localData =  JsonUtility.FromJson<GameData>(_json);

            return _localData;
        }
    }
    
    public static void ResetCurrentSceneIndex()
    {
        int skippedScenesAmount = SceneHandler.GetActiveSceneIndex() + 1;
        _localData.CurrentSceneIndex = skippedScenesAmount;
    }

    private static bool SaveFileExists()
    {
        return File.Exists(GetFilePath());
    }
    
    private static void ResetAllData()
    {
        ResetCurrentSceneIndex();
        ResetAudioMixerValue();
        ResetQualitySettings();
    }

    private static void ResetAudioMixerValue()
    {
        _localData.AudioMixerValue = 1f;
    }
    
    private static void ResetQualitySettings()
    {
        _localData.QualitySettingsIndex = 0;
        
         // _localData.CurrentResolutionWidth = Screen.currentResolution.width;
         // _localData.CurrentResolutionHeight = Screen.currentResolution.height;
        _localData.CurrentResolutionWidth = 1600;////////native resolution
        _localData.CurrentResolutionHeight = 900;///////native resolution
        
        _localData.IsFullscreen = true;
    }
    
    private static string GetFilePath()
    {
        return Path.Combine(Application.persistentDataPath, _fileName);
    }
    
    public static GameData GetLocalData()
    {
        return _localData;
    }
}
