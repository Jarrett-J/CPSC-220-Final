using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Player : Singleton<Player>
{
    private string path;

    public BodyPart defaultHat;
    public BodyPart defaultHead;
    public BodyPart defaultBody;

    public int Points { get; set; }

    public string hatName;
    public string headName;
    public string bodyName;

    public BodyPart Hat { get; set; }

    public BodyPart Head { get; set; }

    public BodyPart Body { get; set; }

    private void Start()
    {
        path = Application.persistentDataPath + "/player.dat";
        DontDestroyOnLoad(gameObject);
        Load();
    }


    private void InitLevelData()
    {
        Points = 0;
        defaultHat.owned = true;
        defaultHead.owned = true;
        defaultBody.owned = true;
        Hat = defaultHat;
        Head = defaultHead;
        Body = defaultBody;
        hatName = defaultHat.part.name;
        headName = defaultHead.part.name;
        bodyName = defaultBody.part.name;
    }

    private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData(this);
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        try
        {
            if (File.Exists(path))
            {
                PartDatabase db = PartDatabase.Instance;

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(path, FileMode.Open);
                PlayerData data = (PlayerData)bf.Deserialize(file);
                file.Close();

                Points = data.points;
                hatName = data.hat;
                headName = data.head;
                bodyName = data.body;

                Hat = db.FindHat(hatName);
                Head = db.FindHead(headName);
                Body = db.FindBody(bodyName);

                Hat.owned = true;
                Head.owned = true;
                Body.owned = true;
            }
            else
            {
                InitLevelData();
            }
        }
        catch (Exception e)
        {
            print(e.Message);
            InitLevelData();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

}
