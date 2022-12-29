using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RecordsManager : MonoBehaviour
{
    [SerializeField]
    private string fileName;
    private string dataPath;
    
    private RecordsCollection recordsCollection;

    private int currentLevel;
    private float startTime;

    public float StartTime { get => startTime; set => startTime = value; }
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public RecordsCollection RecordsCollection { get => recordsCollection; set => recordsCollection = value; }

    private void Awake()
    {
        CurrentLevel = -1;
        startTime = -1;
        dataPath = Application.persistentDataPath + "/" + fileName;
        if(!File.Exists(dataPath))
        {
            recordsCollection = new RecordsCollection() { records = new Record[0] };
            using (StreamWriter stream = new StreamWriter(dataPath))
            {
                string json = JsonUtility.ToJson(RecordsCollection);
                stream.Write(json);
            }
        }
        LoadRecords();
    }

    public void LoadRecords()
    {
        using (StreamReader stream = new StreamReader(dataPath))
        {
            string json = stream.ReadToEnd();
            RecordsCollection = JsonUtility.FromJson<RecordsCollection>(json);
        }
    }

    public void SaveRecord(int level, float time)
    {
        updateData(level, time);

        using (StreamWriter stream = new StreamWriter(dataPath))
        {
            string json = JsonUtility.ToJson(RecordsCollection);
            stream.Write(json);
        }
    }

    private void updateData(int level, float time)
    {
        Record[] records;
        if (level > RecordsCollection.records.Length)
        {
            records = new Record[RecordsCollection.records.Length + 1];
            for (int i = 0; i < RecordsCollection.records.Length; i++)
            {
                records[i] = RecordsCollection.records[i];
            }
            records[RecordsCollection.records.Length] = new Record() { level = level, time = time };
        }
        else
        {
            records = new Record[RecordsCollection.records.Length];
            for (int i = 0; i < RecordsCollection.records.Length; i++)
            {
                records[i] = RecordsCollection.records[i];
                records[level - 1].time = time;
            }
        }

        RecordsCollection = new RecordsCollection() { records = records };
    }
}
