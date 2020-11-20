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
    private string _gameStatePath;

    void Start()
    {
        _racketColorPath = Directory.GetCurrentDirectory() + "\\GameData" + "\\RacketColor.ark";
        _gameStatePath = Directory.GetCurrentDirectory() + "\\GameData" + "\\GameSave.ark";
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

    public void SaveGameState()
    {
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

        _storage.SaveData(gameState, _gameStatePath);
    }

    public GameState LoadGameState()
    {
        if (_storage.LoadData<GameState>(_gameStatePath) == default) return default;

        return _storage.LoadData<GameState>(_gameStatePath);
    }
}
