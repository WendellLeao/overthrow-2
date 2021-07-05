using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static GameData _gameData = new GameData();
    private static GameData _loadedGameData;

    private static string _jsonFilePath, _jsonFile, _json;

    public static GameData GetLoadedGameData => _loadedGameData;
    public static int GetLoadedLevelIndex => _loadedGameData.currentLevelIndex;

    public static void SaveGame()
    {
        _jsonFile = "/data.json";

        _jsonFilePath = Application.persistentDataPath + "/_Project/GameData" + _jsonFile;

        _json = JsonUtility.ToJson(_gameData);

        File.WriteAllText(_jsonFilePath, _json);
    }
    
    public static void LoadGame()
    {      
        _jsonFile = "/data.json";

        _jsonFilePath = Application.persistentDataPath + "/_Project/GameData" + _jsonFile;

        if(File.Exists(_jsonFilePath))//C:\Users\leaow\AppData\LocalLow\LeaoSoft\Overthrow 2
        {
            ReadJsonFile();
        }
        else
        {
            SaveGame(); //Create a new file

            ReadJsonFile();
        }
    }

    public static void SetCurrentLevelIndex(int currentSceneIndex)
    {
        _gameData.currentLevelIndex = currentSceneIndex;
    }
    
    private static void ReadJsonFile()
    {
        _json = File.ReadAllText(_jsonFilePath);

        _loadedGameData = JsonUtility.FromJson<GameData>(_json);
    }
}