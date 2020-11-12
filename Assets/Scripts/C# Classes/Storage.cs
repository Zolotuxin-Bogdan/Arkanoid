using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Storage
{
    public void SaveData<T>(T data, string path)
    {
        //Debug.Log(data);
        //Debug.Log(SerializeToJson(data));

        File.WriteAllText(path, SerializeToJson(data));
    }

    public T LoadData<T>(string path)
    {
        return DeserializeJson<T>(File.ReadAllText(path));
    }

    private static string SerializeToJson<T>(T obj) =>
        JsonConvert.SerializeObject(obj);
    private static T DeserializeJson<T>(string obj) =>
        JsonConvert.DeserializeObject<T>(obj);
}
