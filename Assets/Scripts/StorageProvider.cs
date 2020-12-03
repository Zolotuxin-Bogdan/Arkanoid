using System.IO;
using UnityEngine;

public class StorageProvider
{
    private readonly Storage _storage = new Storage();

    private string _racketColorPath;
    private string _gameSavesPath;

    void Start()
    {
        _racketColorPath = Directory.GetCurrentDirectory() + "\\GameData" + "\\RacketColor.ark";
        _gameSavesPath = Directory.GetCurrentDirectory() + "\\GameData" + "\\GameSaves.ark";
    }

    public void SaveRacketColor(CustomColor racketSaveColor)
    {
        _storage.SaveData(racketSaveColor, _racketColorPath);
    }

    public Color LoadRacketColor()
    {
        TryLoadRacketColor(out var loadColor);
        return loadColor;
    }

    public bool TryLoadRacketColor(out Color result)
    {
        try
        {
            result = _storage.LoadData<CustomColor>(_racketColorPath);
            return true;
        }
        catch (FileNotFoundException)
        {
            result = new Color(255, 255, 255);
            return false;
        }
    }

    public void SaveGameCellsDict(SaveCellsDict saveCellsDict)
    {
        _storage.SaveData(saveCellsDict, _gameSavesPath);
    }

    public SaveCellsDict LoadGameCellsDict()
    {
        TryLoadGameCellsDict(out var saveCellsDict);
        return saveCellsDict;
    }

    public bool TryLoadGameCellsDict(out SaveCellsDict result)
    {
        try
        {
            result = _storage.LoadData<SaveCellsDict>(_gameSavesPath);
            return true;
        }
        catch (FileNotFoundException)
        {
            result = null;
            return false;
        }
    }
}
