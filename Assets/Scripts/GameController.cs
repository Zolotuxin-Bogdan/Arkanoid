using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject WinCanvas;
    public GameObject LoseCanvas;
    public GameObject Ball;
    public GameObject BallSpawnLocation;

    public LoseGame LoseGame;
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (LoseGame.IsLose)
        {
            LoseGame.IsLose = false;
            GameLoosed();
        }
    }

    //////////////////////////////////////////////////////
    public void GameFinished()
    {
        Time.timeScale = 0;
        WinCanvas.SetActive(true);
    }

    void GameLoosed()
    {
        Time.timeScale = 0;
        LoseCanvas.SetActive(true);
    }
    //////////////////////////////////////////////////////

    public void PlayGame()
    {
        Time.timeScale = 1;
        WinCanvas.SetActive(false);
        LoseCanvas.SetActive(false);
        Ball.transform.position = BallSpawnLocation.transform.position;
        Ball.GetComponent<BallMovement>().SetDefaultBallMovement();
    }
}
