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
        var racketColor = RacketColor.GetComponent<Image>().color;
        var racketSaveColor = new RacketColor
        {
            RedColor = racketColor.r,
            GreenColor = racketColor.g,
            BlueColor = racketColor.b
        };

        _storage.SaveData(racketSaveColor, _racketColorPath);
    }

    public Color LoadRacketColor()
    {
        var racketLoadColor = _storage.LoadData<RacketColor>(_racketColorPath);
        return new Color(racketLoadColor.RedColor, racketLoadColor.GreenColor, racketLoadColor.BlueColor);
    }
}
