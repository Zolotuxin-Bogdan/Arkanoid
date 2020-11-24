using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StorageProvider : MonoBehaviour
{
    public GameObject RacketColor;
    public GameObject Score;
    public GameObject BallMovement;
    public GameObject RacketMovement;

    private readonly Storage _storage = new Storage();

    private string _racketColorPath;
    private string _gameSavesPath;

    void Start()
    {
        _racketColorPath = Directory.GetCurrentDirectory() + "\\GameData" + "\\RacketColor.ark";
        _gameSavesPath = Directory.GetCurrentDirectory() + "\\GameData" + "\\GameSaves.ark";
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
        if (_storage.LoadData<RacketColor>(_racketColorPath) == default)
        { 
            return new Color(255, 255, 255);
        }

        return _storage.LoadData<RacketColor>(_racketColorPath);
    }

    public void SaveGameCellsDict(int saveIndex)
    {
        var saveCellsDict = new SaveCellsDict();
        
        if (LoadGameCellsDict() != default)
        {
            saveCellsDict = LoadGameCellsDict();
        }

        var globalScore = Score.GetComponent<Score>().GlobalScore;
        var localScore = Score.GetComponent<Score>().LocalScore;

        var ballPosition = BallMovement.GetComponent<BallMovement>().GetBallPosition();
        var ballMovement = BallMovement.GetComponent<BallMovement>().GetTempBallMovement();
        var xBallDirection = BallMovement.GetComponent<BallMovement>().DirectionX;
        var yBallDirection = BallMovement.GetComponent<BallMovement>().DirectionY;

        var racketPosition = RacketMovement.GetComponent<RacketMovement>().GetRacketPosition();

        var level = BlockManager.Instance.CurrentLevel;
        var levelState = BlockManager.Instance.CurrentLevelState;

        var gameState = new GameState()
        {
            GlobalScore = globalScore,
            LocalScore = localScore,
            BallPosition = ballPosition,
            BallMovement = ballMovement,
            X_BallDirection = xBallDirection,
            Y_BallDirection = yBallDirection,
            RacketPosition = racketPosition,
            Level = level,
            LevelState = levelState
        };

        var timeStamp = DateTime.Now;

        var saveCell = new SaveCell()
        {
            GameState = gameState,
            TimeStamp = timeStamp
        };

        saveCellsDict.SaveCells[saveIndex] = saveCell;

        _storage.SaveData(saveCellsDict, _gameSavesPath);
    }

    public SaveCellsDict LoadGameCellsDict()
    {
        if (_storage.LoadData<SaveCellsDict>(_gameSavesPath) == default) return default;

        return _storage.LoadData<SaveCellsDict>(_gameSavesPath);
    }
}
