using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string _fileName = "gameData.json";

    public static GameData SaveGameData()
    {
        GameData gameData = GameData.Instance;

        string _json = JsonUtility.ToJson(gameData);

        File.WriteAllText(GetFilePath(), _json);

        return gameData;
    }

    public static GameData LoadGameData()
    {
        string path = GetFilePath();

        if(!SaveFileExists())
        {
            return SaveGameData(); //Create a new save file
        }
        else
        {
            string _json = File.ReadAllText(GetFilePath());

            GameData.Instance =  JsonUtility.FromJson<GameData>(_json);

            return GameData.Instance;
        }
    }

    public static bool SaveFileExists()
    {
        return File.Exists(GetFilePath());
    }

    public static void DeleteSave()
    {
        File.Delete(GetFilePath());

        GameData.Instance.Reset();
    }

    private static string GetFilePath()
    {
        return Path.Combine(Application.persistentDataPath, _fileName);
    }
}