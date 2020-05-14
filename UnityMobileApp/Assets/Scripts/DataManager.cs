using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<DataManager>();
            return instance;
        }
    }
    
    
    public Player data;

    public static string file; // = Application.persistentDataPath + /profileSave.json";
    
    private string profileInfo = "PlayerProfile";

    public DataManager(){}

    public void Start()
    {
        file = Application.dataPath + "/profileSave.json";
    }
    // public DataManager(string filePath)
    // {
    //     file = filePath + "/profileSave.json";
    // }

    public void Save()
    {
        //Debug.Log("file variable :" + file);
        if (data == null)
            Debug.LogError("data is null");
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(profileInfo, json);
        //WriteToFile(json);
    }

    public void Load()
    {
        data = new Player();
        //string json = ReadFromFile();
        string json = PlayerPrefs.GetString(profileInfo);
        Debug.Log(json);
        JsonUtility.FromJsonOverwrite(json, data);
    }
    
    public void UpdateUserScore(uint addScore)
    {
        string json = ReadFromFile();
        data = new Player();
        JsonUtility.FromJsonOverwrite(json, data);
        data.score += addScore;
        
        string jsonUpdated = JsonUtility.ToJson(data);
        WriteToFile(jsonUpdated);
        Debug.Log("Score updated");
    }

    public void UpdateUsername(string newUsername)
    {
        string json = ReadFromFile();
        data = new Player();
        JsonUtility.FromJsonOverwrite(json, data);
        data.username = newUsername;
        
        string jsonUpdated = JsonUtility.ToJson(data);
        WriteToFile(jsonUpdated);
     
        Debug.Log("Username updated");
    }
    
    private void WriteToFile(string json)
    {
        using (FileStream fileStream = new FileStream(file, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
                Debug.Log("end saving in file");
            }
        }
    }

    private string ReadFromFile()
    { 
        if (File.Exists(file))
        {
            Debug.Log("File IS EXIST");
            using (StreamReader reader = new StreamReader(file))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        } 
        Debug.Log("File does NOT exist");
        return "";
    }
}
