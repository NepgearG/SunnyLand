using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManagement : MonoBehaviour
{
    public static SaveManagement instance;
    public SaveData datas;
    public bool hasLoaded;


    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            DeleteSaveData();
        }
    }

    public void Save()
    {
        //AppData\local\Packages\SunnyLand\LocalStates
        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + datas.saveName + ".save", FileMode.Create);
        serializer.Serialize(stream, datas);
        stream.Close();
        Debug.Log("Saved");
    }

    public void Load()
    {
        //AppData\local\Packages\SunnyLand\LocalStates
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + datas.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + datas.saveName + ".save", FileMode.Open);
            datas = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            Debug.Log("Loaded");
            hasLoaded = true;
        }
    }

    public void DeleteSaveData()
    {
        //AppData\local\Packages\SunnyLand\LocalStates
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + datas.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + datas.saveName + ".save");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public string saveName;

    public Vector3 respawnPosition;

    public bool doorOpen;

    public int lives;

    //score save
    public int cherryNums;
    public int diamondNums;
    public int score;
}