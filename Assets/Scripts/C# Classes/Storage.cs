using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Storage
{
    public void SaveData<T>(T data, string path)
    {
        var directoryName = Path.GetDirectoryName(path);
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        using (var sw = new StreamWriter(path))
        {
            sw.WriteLine(SerializeToJson(data));
        }     
    }

    public T LoadData<T>(string path)
    {
        using (var sr = new StreamReader(path))
        {
            var dataFromFile = sr.ReadLine();
            return DeserializeJson<T>(dataFromFile);
        }
    }

    private static string SerializeToJson<T>(T obj) =>
        JsonConvert.SerializeObject(obj);
    private static T DeserializeJson<T>(string obj) =>
        JsonConvert.DeserializeObject<T>(obj);
}
