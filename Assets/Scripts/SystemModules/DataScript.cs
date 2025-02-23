using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class DataScript
{
    [System.Serializable]
    private class Data
    {
        public List<int> array;

        public Data(List<int> arr)
        {
            this.array = arr;
        }
    }

    public static string fileName = "cards.json";

    public static void SaveData(List<int> arr)
    {
        Data data = new Data(arr);

        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, json);
    }

    public static List<int> LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);
            if (data != null && data.array != null)
            {
                return data.array;
            }
        }

        return new List<int>() { };
    }
}