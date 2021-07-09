using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string _fileName = "gameData.save";

    public static GameData SaveGameData()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        string path = GetFilePath();

        using(FileStream fileStream = File.Create(path))
        {
            GameData gameData = GameData.Instance;

            binaryFormatter.Serialize(fileStream, gameData);

            fileStream.Close();
            
            return gameData;
        }
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
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using(FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                GameData gameData = binaryFormatter.Deserialize(fileStream) as GameData;

                fileStream.Close();

                return gameData;
            }
        }
    }

    public static bool SaveFileExists()
    {
        return File.Exists(GetFilePath());
    }

    public static void DeleteSave()
    {
        File.Delete(GetFilePath());
    }

    private static string GetFilePath()
    {
        return Path.Combine(Application.persistentDataPath, _fileName);
    }
}