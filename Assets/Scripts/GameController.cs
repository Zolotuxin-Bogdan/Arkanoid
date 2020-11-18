using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;

    public GameObject WinCanvas;
    public GameObject LoseCanvas;
    public GameObject Ball;
    public GameObject BallSpawnLocation;

    public LoseGame LoseGame;

    public bool IsPaused;

    private readonly UserInput_KeyBoard _userInputKeyBoard = new UserInput_KeyBoard();
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        IsPaused = false;
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
        Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        WinCanvas.SetActive(true);
    }

    void GameLoosed()
    {
        IsPaused = true;
        Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        LoseCanvas.SetActive(true);
    }
    //////////////////////////////////////////////////////

    public void PlayGame()
    {
        IsPaused = false;
        WinCanvas.SetActive(false);
        LoseCanvas.SetActive(false);
        Ball.transform.position = BallSpawnLocation.transform.position;
        Ball.GetComponent<BallMovement>().SetDefaultBallMovement();
    }
}
