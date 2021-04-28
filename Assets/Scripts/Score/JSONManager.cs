using UnityEngine;
using System.IO;

public static class JSONManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "GameScores.txt";

    public static void SaveJSON(ScoreTable ST)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(ST);
        File.WriteAllText(dir + fileName, json);
    }

    public static ScoreTable LoadJSON()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        ScoreTable ST = new ScoreTable();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            ST = JsonUtility.FromJson<ScoreTable>(json);
        }
        else
        {
            Debug.LogError("File doesn´t exists");
        }

        return ST;
    }

}