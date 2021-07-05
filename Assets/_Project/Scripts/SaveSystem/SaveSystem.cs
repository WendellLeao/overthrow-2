using UnityEngine;
using System.IO;

[CreateAssetMenu]
public sealed class SaveSystem : ScriptableObject
{
    private GameData gameData = new GameData();

    private GameData loadedGameData;
    public GameData GetLoadedGameData => loadedGameData;

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(gameData);

        File.WriteAllText(Application.dataPath + "/_Project/GameData/saveFile.json", json);
    }
    
    public void LoadGame()
    {        
        string json = File.ReadAllText(Application.dataPath + "/_Project/GameData/saveFile.json");

        loadedGameData = JsonUtility.FromJson<GameData>(json);
    }

    public void SaveCurrentLevel(int currentSceneIndex)
    {
        gameData.currentLevelIndex = currentSceneIndex;

        SaveGame();
    }

    public int LoadCurrentLevelIndex()
    {
        LoadGame();

        return loadedGameData.currentLevelIndex;
    }
}

public sealed class GameData
{
    public int currentLevelIndex;
}