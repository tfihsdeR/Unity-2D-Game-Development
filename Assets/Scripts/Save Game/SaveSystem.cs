using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    public static void SaveGame(PlayerInfo player) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.dinc";

        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData(player); 
        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/player.dinc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            return data;
        }else
        {
            Debug.LogError("Savefile not found in " + path);
            return null;
        }
    }
}
