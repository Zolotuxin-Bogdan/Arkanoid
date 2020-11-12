using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StorageProvider : MonoBehaviour
{
    public GameObject RacketColor;

    private readonly Storage _storage = new Storage();

    private string _racketColorPath;

    void Start()
    {
        _racketColorPath = Directory.GetCurrentDirectory() + "\\GameData" + "\\RacketColor.ark";
    }

    public void SaveRacketColor()
    {
        var directoryName = Path.GetDirectoryName(_racketColorPath);
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        if (!File.Exists(_racketColorPath))
        {
            File.Create(_racketColorPath);
        }

        var racketColor = RacketColor.GetComponent<Image>().color;

        _storage.SaveData(racketColor, _racketColorPath);
    }

    public Color LoadRacketColor()
    {
        return _storage.LoadData<Color>(_racketColorPath);
    }
}
