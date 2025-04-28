using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

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
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd(); // read the data from the file
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad); 
            }
            catch (Exception e)
            {
                Debug.LogError("Could not load data from " + fullPath + "/n" + e);
            }

        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)); // creates the directory if it doesn't exist

            string dataToStore = JsonUtility.ToJson(data, true); // serialize the data to JSON format

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore); // write the data to the file
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Could not create directory: " + fullPath + "/n" + e);
            
        }
    }
}
