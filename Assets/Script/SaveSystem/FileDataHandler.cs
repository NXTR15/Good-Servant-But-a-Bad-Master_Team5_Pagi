using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler (string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        // Path.combine to account different OS
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath)) 
        {
            try
            {
                //loaded serialized data
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //Deserialize from JSON to C#
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when try to load data from file: " +  fullPath + "\n" + e);
            } 
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        // Path.combine to account different OS
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create directory file will be written if its not in computer yet
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            //Serialize game data object
            string dataToStore = JsonUtility.ToJson(data, true);

            // write the serialize to file
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
            Debug.LogError("Error occued when trying to save: " + fullPath + "\n" + e);
        }
    }
}
