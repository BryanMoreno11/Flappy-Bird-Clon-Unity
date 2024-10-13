using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler 
{

    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string daaDirPath, string dataFileName)
    {
        this.dataDirPath = daaDirPath;
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
                using (FileStream stream = new FileStream(fullPath, FileMode.Open)){

                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        dataToLoad = streamReader.ReadToEnd();

                    }
                }
                //Deserealización, JSON a un Objeto de C# GameData
                loadedData= JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch (Exception e)
            {

            }
        }
        return loadedData;

    }

    public void Save(GameData gameData)
    {
        string fullPath= Path.Combine(dataDirPath, dataFileName);
        try
        {
            //Crea un directorio por primera vez en caso de que no exista
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            //Serializar el GameDataObject de C# a formato JSON
            string dataToStore = JsonUtility.ToJson(gameData);
            //a la data serializada la vamos a gurdar en un archivo
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
            Debug.LogError("Error al guardar en el directorio" + fullPath + " El error provocado es " + "\n" + e);
        }

    }
}
