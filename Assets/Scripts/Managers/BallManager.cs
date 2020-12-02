using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance { get; private set; }

    public float SlowMoBallTime { get; set; } = 3f;
    public float SlowMoMultiplier { get; set; } = 4f;

    public float BallSpeed { get; set; } = 7f;

    public GameObject Ball;

    private List<GameObject> _balls = new List<GameObject>();

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


    public void SetCurrentBall(GameObject ball)
    {
        Ball = ball;
    }

    public GameObject SpawnBall(GameObject ball)
    {
        var createdBall = Instantiate(ball);
        _balls.Add(createdBall);
        return createdBall;
    }

    public void DestroyBall(GameObject ball)
    {
        Destroy(ball);
        _balls.Remove(ball);
        if (_balls.Count <= 0)
        {
            GameController.Instance.IsLose = true;
        }
    }

    public void DestroyAllBalls()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in balls)
        {
            Destroy(ball);
        }
        _balls.Clear();
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
        _balls.Add(newBall);
        newBall.GetComponent<BallMovement>().SetBallMovement(ballMovement);
        newBall.GetComponent<BallMovement>().SetBallPosition(ballPosition);
        newBall.GetComponent<BallMovement>().Set_X_Direction(directionX);
        newBall.GetComponent<BallMovement>().Set_Y_Direction(directionY);
        newBall.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 0f);
    }

    public void SlowMoBalls()
    {
        StartCoroutine(SlowMoBallsCoroutine());
    }
    private IEnumerator SlowMoBallsCoroutine()
    {
        BallSpeed /= SlowMoMultiplier;
        foreach (var ball in _balls)
        {
            ball.GetComponent<BallMovement>().Speed = BallSpeed;
            var directionX = ball.GetComponent<BallMovement>().DirectionX;
            var directionY = ball.GetComponent<BallMovement>().DirectionY;
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(directionX * BallSpeed, directionY * BallSpeed);
            
        }
        yield return new WaitForSeconds(SlowMoBallTime);
        BallSpeed *= SlowMoMultiplier;
        foreach (var ball in _balls)
        {
            ball.GetComponent<BallMovement>().Speed = BallSpeed;
            var directionX = ball.GetComponent<BallMovement>().DirectionX;
            var directionY = ball.GetComponent<BallMovement>().DirectionY;
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(directionX * BallSpeed, directionY * BallSpeed);
        }
    }
}
