using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance { get; private set; }


    public GameObject Ball;

    public int BallCount;

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

    public void DecreaseBallCount()
    {
        BallCount--;
        if (BallCount <= 0)
        {
            GameController.Instance.IsLose = true;
        }
    }

    public void SetCurrentBall(GameObject ball)
    {
        Ball = ball;
    }

    public GameObject SpawnStartBall(GameObject ball)
    {
        BallCount = 1;
        return Instantiate(ball);
    }

    public GameObject SpawnBall(GameObject ball)
    {
        return Instantiate(ball);
    }

    public void DestroyAllBalls()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in balls)
        {
            Destroy(ball);
        }
    }

    public void StopAllBalls()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in balls)
        {
            ball.GetComponent<BallMovement>().StopBallMovement();
        }
    }

    public void RunAllBalls()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in balls)
        {
            ball.GetComponent<BallMovement>().SetBallMovement(ball.GetComponent<BallMovement>().GetTempBallMovement());
        }
    }

    public void SpawnDoubleBall()
    {
        var ballMovement = Ball.GetComponent<BallMovement>().GetInvertedMovement();
        var ballPosition = Ball.GetComponent<BallMovement>().GetBallPosition();
        var directionX = Ball.GetComponent<BallMovement>().GetInvertedDirectionX();
        var directionY = Ball.GetComponent<BallMovement>().GetInvertedDirectionY();
        var newBall = Instantiate(Ball, ballPosition, Ball.transform.rotation);
        BallCount++;
        newBall.GetComponent<BallMovement>().SetBallMovement(ballMovement);
        newBall.GetComponent<BallMovement>().SetBallPosition(ballPosition);
        newBall.GetComponent<BallMovement>().Set_X_Direction(directionX);
        newBall.GetComponent<BallMovement>().Set_Y_Direction(directionY);
        newBall.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 0f);
    }
}
