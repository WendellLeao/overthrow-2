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
            _localData.ResetAllData();
            
            return SaveGameData(); //Create a new save file
        }
        else
        {
            string _json = File.ReadAllText(GetFilePath());

            _localData =  JsonUtility.FromJson<GameData>(_json);

            return _localData;
        }
    }

    private static void DeleteSave()
    {
        File.Delete(GetFilePath());

        _localData.ResetCurrentSceneIndex();
        _localData.ResetAudioMixerValue();
    }
    
    private static bool SaveFileExists()
    {
        return File.Exists(GetFilePath());
    }

    public static GameData GetLocalData()
    {
        return _localData;
    }
    
    private static string GetFilePath()
    {
        return Path.Combine(Application.persistentDataPath, _fileName);
    }
}
