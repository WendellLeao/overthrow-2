using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SerializationManager
{
    private static string _saveFile = ".save";

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

        if(!File.Exists(path))
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

    public static void DeleteSave()
    {
        File.Delete(GetFilePath());
    }

    private static string GetFilePath()
    {
        return Application.persistentDataPath + "/gameData.save";
    }
}