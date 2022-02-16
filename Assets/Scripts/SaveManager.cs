using UnityEngine;
using System.IO;
using MItem = Assets.Scripts.Models.Item;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "MyData.txt";

    public static void Save(MItem item)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(item);
        File.WriteAllText(dir + fileName, json);
    }

    public static MItem Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        MItem item = new MItem();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            item = JsonUtility.FromJson<MItem>(json);
        }
        else
        {
            Debug.Log("File does not exist.");
        }

        return item;
    }
}
