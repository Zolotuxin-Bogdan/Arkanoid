using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float Speed = 7f;

    public float DirectionY { get; private set; } = 1f;
    public float DirectionX { get; private set; } = 1f;
    private Rigidbody2D _rb;
    private Vector2 _tempBallMovement;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetDefaultBallMovement()
    {
        _rb.velocity = new Vector2(DirectionX * Speed, DirectionY * Speed);
    }

    public Vector2 GetBallMovement()
    {
        return _rb.velocity;
    }

    public Vector2 GetTempBallMovement()
    {
        return _tempBallMovement;
    }

    public void SetBallMovement(Vector2 ballMovement)
    {
        _rb.velocity = ballMovement;
    }

    public Vector3 GetBallPosition()
    {
        return transform.position;
    }

    public void SetBallPosition(Vector3 ballPosition)
    {
        transform.position = ballPosition;
    }

    public void StopBallMovement()
    {
        _tempBallMovement = GetBallMovement();
        _rb.velocity = new Vector2(0, 0);
    }

    public void Set_X_Direction(float value)
    {
        DirectionX = value;
    }

    public void Set_Y_Direction(float value)
    {
        DirectionY = value;
    }

    public Vector2 GetInvertedMovement()
    {
        return new Vector2(-1f * Speed * DirectionX, -1f * Speed * DirectionY);
    }

    public float GetInvertedDirectionX()
    {
        return DirectionX * -1f;
    }

    public float GetInvertedDirectionY()
    {
        return DirectionY * -1f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
            //DirectionY *= -1f;
            //col.gameObject.GetComponent<BallMovement>().DirectionY *= -1f;
        }

        if (col.gameObject.CompareTag("Block"))
        {
            var ball = gameObject;
            BallManager.Instance.SetCurrentBall(ball);
            var block = col.gameObject;
            BlockManager.Instance.DestroyBlock(block);
            
        }

        if (!GameController.Instance.IsPaused)
        {
            if (col.gameObject.name == "Border Top" || col.gameObject.CompareTag("Block"))
            {
                DirectionY *= -1f;
                _rb.velocity = new Vector2(Speed * DirectionX, Speed * DirectionY);
                AudioManager.Instance.PlayBallBounceSound();
            }

            if (col.gameObject.name == "Border Left" || col.gameObject.name == "Border Right")
            {
                DirectionX *= -1f;
                _rb.velocity = new Vector2(Speed * DirectionX, Speed * DirectionY);
                AudioManager.Instance.PlayBallBounceSound();
            }

            if (col.gameObject.name == "Racket")
            {
                DirectionY *= -1f;
                _rb.velocity = new Vector2(Speed * DirectionX, Speed * DirectionY);
                AudioManager.Instance.PlayBallBounceSound();
            }
        }
    }
}