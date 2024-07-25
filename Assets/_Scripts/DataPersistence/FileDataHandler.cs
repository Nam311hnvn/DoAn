using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        /*GameData loadedData = null;*/
        if (File.Exists(fullPath))
        {           
            string content = File.ReadAllText(fullPath);
            Debug.Log("fileHandleContent: "+content);
            if (string.IsNullOrEmpty(content))
            {   
                GameData gameDataDefault = new GameData();
                string dataToStore = JsonUtility.ToJson(gameDataDefault, true);
                File.WriteAllText(fullPath,dataToStore);
                return gameDataDefault;
            }else
            {
                return JsonConvert.DeserializeObject<GameData>(content);
            }

        }
        else
        {

        //neu co du lieu thi load data
        GameData gameDataDefault = new GameData();
        string dataToStore = JsonUtility.ToJson(gameDataDefault, true);
        File.WriteAllText(fullPath, dataToStore);
        return gameDataDefault;
        }
    }

    public void Save(GameData data)
    {
        //use Path.combine to account for different OS having path seperator 
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create the directory the file will be written to if it doesnt already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize the C# game data object into Json
            string dataToStore = JsonUtility.ToJson(data, true);
            /*string dataToStore = JsonConvert.SerializeObject(data, Formatting.Indented);*/

            //write the serialize data to file 
            //dung ham using de dong file khi da su dung xong
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file :" + fullPath + "\n" + e);
        }
    }

    public void DeleteJsonFile()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            Debug.Log("JSON file deleted");
        }
    }
}
