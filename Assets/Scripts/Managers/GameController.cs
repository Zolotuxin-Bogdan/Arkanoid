using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public GameObject WinCanvas;
    public GameObject LoseCanvas;
    public GameObject PauseCanvas;
    public GameObject SaveGameCanvas;
    public GameObject Ball;

    public LoseGame LoseGame;
    public StorageProvider StorageProvider;
    public Score Score;
    public RacketMovement RacketMovement;

    public bool IsPaused;
    public bool IsGameLoaded;

    private readonly UserInput_KeyBoard _userInputKeyBoard = new UserInput_KeyBoard();
    private readonly SessionStorage _sessionStorage = SessionStorage.Instance;
    private BallMovement _ballMovement;
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
        _ballMovement = Ball.GetComponent<BallMovement>();
        BlockManager.Instance.GameFinishedEvent += GameFinished;
        if (_sessionStorage.GameLoaded)
        {
            LoadGame(_sessionStorage.LoadCellIndex);
        }
        BlockManager.Instance.LoadLevel();
        if (!_sessionStorage.GameLoaded)
        {
            _ballMovement.SetDefaultBallMovement();
        }
    }
    void Update()
    {
        if (LoseGame.IsLose)
        {
            LoseGame.IsLose = false;
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
        _ballMovement.SetDefaultBallPosition();
        _ballMovement.StopBallMovement();
        WinCanvas.SetActive(true);
    }

    void GameLoosed()
    {
        IsPaused = true;
        _ballMovement.StopBallMovement();
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
            _ballMovement.StopBallMovement();
        }
        IsPaused = true;
        PauseCanvas.SetActive(true);
    }

    void ResumeGame()
    {
        IsPaused = false;
        _ballMovement.SetBallMovement(_ballMovement.GetTempBallMovement());
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
        _ballMovement.SetDefaultBallPosition();
        _ballMovement.SetDefaultBallMovement();
    }

    public void LoadGame(int loadCellIndex)
    {
        var gameCellsDict = StorageProvider.LoadGameCellsDict();
        var gameState = gameCellsDict.SaveCells[loadCellIndex].GameState;

        Score.SetGlobalScore(gameState.GlobalScore);
        Score.SetLocalScore(gameState.LocalScore);

        _ballMovement.SetBallPosition(gameState.BallPosition);
        _ballMovement.SetBallMovement(gameState.BallMovement);
        _ballMovement.Set_X_Direction(gameState.X_BallDirection);
        _ballMovement.Set_Y_Direction(gameState.Y_BallDirection);

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
