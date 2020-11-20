using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public GameObject WinCanvas;
    public GameObject LoseCanvas;
    public GameObject Ball;

    public LoseGame LoseGame;

    public bool IsPaused;

    private readonly UserInput_KeyBoard _userInputKeyBoard = new UserInput_KeyBoard();
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
    }
    void Update()
    {
        if (LoseGame.IsLose)
        {
            LoseGame.IsLose = false;
            GameLoosed();
        }

        if (_userInputKeyBoard.Is_X_Pressed())
        {
            BlockManager.Instance.DestroyAllBlocks();
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
    //////////////////////////////////////////////////////

    public void PlayGame()
    {
        IsPaused = false;
        WinCanvas.SetActive(false);
        LoseCanvas.SetActive(false);
        _ballMovement.SetDefaultBallPosition();
        _ballMovement.SetDefaultBallMovement();
    }
}
