using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveManager : MonoBehaviour
{
    public GameObject RacketColor;

    public GameObject Score;
    public GameObject RacketMovement;

    private readonly StorageProvider _storageProvider = new StorageProvider();

    public void SaveRacketColor()
    {
        var racketColor = RacketColor.GetComponent<Image>().color;
        var racketSaveColor = new CustomColor
        {
            RedColor = racketColor.r,
            GreenColor = racketColor.g,
            BlueColor = racketColor.b
        };
        _storageProvider.SaveRacketColor(racketSaveColor);
    }

    public void SaveGameCellsDict(int saveIndex)
    {
        var saveCellsDict = new SaveCellsDict();

        if (_storageProvider.LoadGameCellsDict() != null)
        {
            saveCellsDict = _storageProvider.LoadGameCellsDict();
        }

        var globalScore = Score.GetComponent<Score>().GlobalScore;
        var localScore = Score.GetComponent<Score>().LocalScore;

        var ballsList = new List<Ball>();
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in balls)
        {
            var ballObject = new Ball
            {
                BallPosition = ball.GetComponent<BallMovement>().GetBallPosition(),
                BallMovement = ball.GetComponent<BallMovement>().GetTempBallMovement(),
                DirectionX = ball.GetComponent<BallMovement>().DirectionX,
                DirectionY = ball.GetComponent<BallMovement>().DirectionY,
                BallColor = ball.GetComponent<SpriteRenderer>().color
            };
            ballsList.Add(ballObject);
        }

        var ballsCount = balls.Length;


        var racketPosition = RacketMovement.GetComponent<RacketMovement>().GetRacketPosition();

        var level = BlockManager.Instance.CurrentLevel;
        var levelState = BlockManager.Instance.CurrentLevelState;

        var gameState = new GameState()
        {
            GlobalScore = globalScore,
            LocalScore = localScore,
            Balls = ballsList,
            BallsCount = ballsCount,
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
        _storageProvider.SaveGameCellsDict(saveCellsDict);
    }
}
