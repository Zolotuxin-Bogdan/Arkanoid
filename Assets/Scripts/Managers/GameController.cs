using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public GameObject WinCanvas;
    public GameObject LoseCanvas;
    public GameObject PauseCanvas;
    public GameObject SaveGameCanvas;
    public GameObject Ball;

    public StorageProvider StorageProvider;
    public Score Score;
    public RacketMovement RacketMovement;

    public bool IsPaused;
    public bool IsGameLoaded;
    public bool IsLose;

    private readonly UserInput_KeyBoard _userInputKeyBoard = new UserInput_KeyBoard();
    private readonly SessionStorage _sessionStorage = SessionStorage.Instance;
    private BallMovement _ballMovement;
    private GameObject _ball;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }
    void Start()
    {
        IsPaused = false;
        BlockManager.Instance.GameFinishedEvent += GameFinished;
        if (_sessionStorage.GameLoaded)
        {
            LoadGame(_sessionStorage.LoadCellIndex);
        }
        BlockManager.Instance.LoadLevel();
        if (!_sessionStorage.GameLoaded)
        {
            _ball = BallManager.Instance.SpawnStartBall(Ball);
            _ballMovement = _ball.GetComponent<BallMovement>();
            _ballMovement.SetDefaultBallMovement();
        }
    }
    void Update()
    {
        if (IsLose)
        {
            IsLose = false;
            GameLoosed();
        }

        if (_userInputKeyBoard.IsKeyPressed(KeyCode.X))
        {
            BlockManager.Instance.DestroyAllBlocks();
        }

        if (_userInputKeyBoard.IsKeyPressed(KeyCode.Escape))
        {
            GamePaused();
            SaveGameCanvas.SetActive(false);
        }
    }

    //////////////////////////////////////////////////////
    public void GameFinished()
    {
        IsPaused = true;
        BallManager.Instance.DestroyAllBalls();
        WinCanvas.SetActive(true);
    }

    void GameLoosed()
    {
        IsPaused = true;
        BallManager.Instance.DestroyAllBalls();
        LoseCanvas.SetActive(true);
    }

    void GamePaused()
    {
        if (!PauseCanvas.activeSelf)
        {
            StopGame();
        }
        else if (PauseCanvas.activeSelf)
        {
            ResumeGame();
        }
        
    }

    void StopGame()
    {
        if (!IsPaused)
        {
            BallManager.Instance.StopAllBalls();
        }
        IsPaused = true;
        PauseCanvas.SetActive(true);
    }

    void ResumeGame()
    {
        IsPaused = false;
        BallManager.Instance.RunAllBalls();
        PauseCanvas.SetActive(false);
    }
    public void ShowGameSaveCanvas()
    {
        PauseCanvas.SetActive(false);
        SaveGameCanvas.SetActive(true);
    }
    //////////////////////////////////////////////////////

    public void PlayGame()
    {
        IsPaused = false;
        WinCanvas.SetActive(false);
        LoseCanvas.SetActive(false);
        _ball = BallManager.Instance.SpawnStartBall(Ball);
        _ballMovement = _ball.GetComponent<BallMovement>();
        _ballMovement.SetDefaultBallMovement();
    }

    public void LoadGame(int loadCellIndex)
    {
        var gameCellsDict = StorageProvider.LoadGameCellsDict();
        var gameState = gameCellsDict.SaveCells[loadCellIndex].GameState;

        Score.SetGlobalScore(gameState.GlobalScore);
        Score.SetLocalScore(gameState.LocalScore);

        foreach (var ball in gameState.Balls)
        {
            var loadedBall = BallManager.Instance.SpawnBall(Ball);
            var loadedBallMovement = loadedBall.GetComponent<BallMovement>();
            loadedBallMovement.SetBallPosition(ball.BallPosition);
            loadedBallMovement.SetBallMovement(ball.BallMovement);
            loadedBallMovement.Set_X_Direction(ball.DirectionX);
            loadedBallMovement.Set_Y_Direction(ball.DirectionY);
            loadedBall.GetComponent<SpriteRenderer>().color = new Color(ball.BallColor.RedColor, ball.BallColor.GreenColor, ball.BallColor.BlueColor);
        }

        BallManager.Instance.BallCount = gameState.BallsCount;

        RacketMovement.SetRacketPosition(gameState.RacketPosition);

        BlockManager.Instance.SetCurrentLevel(gameState.Level);
        BlockManager.Instance.SetCurrentLevelState(gameState.LevelState);

        IsGameLoaded = true;
    }

    public void SaveGame(int saveCellIndex)
    {
        StorageProvider.SaveGameCellsDict(saveCellIndex);
    }
}
