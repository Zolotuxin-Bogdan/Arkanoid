﻿using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float Speed = 7f;
    public GameObject BallSpawnLocation;

    private float _directionY = 1f;
    private float _directionX = 1f;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        SetDefaultBallMovement();
    }

    public void SetDefaultBallMovement()
    {
        _rb.velocity = (Vector2.up + Vector2.right) * Speed * 1f;
    }

    public void SetDefaultBallPosition()
    {
        transform.position = BallSpawnLocation.transform.position;
    }

    public void StopBallMovement()
    {
        _rb.velocity = new Vector2(0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!GameController.Instance.IsPaused)
        {
            if (col.gameObject.CompareTag("Block"))
            {
                var block = col.gameObject;
                BlockManager.Instance.DestroyBlock(block);
            }

            if (col.gameObject.name == "Border Top" || col.gameObject.CompareTag("Block"))
            {
                _directionY *= -1f;
                _rb.velocity = new Vector2(_directionX * Speed, _directionY * Speed);
            }

            if (col.gameObject.name == "Border Left" || col.gameObject.name == "Border Right")
            {
                _directionX *= -1f;
                _rb.velocity = new Vector2(_directionX * Speed, _directionY * Speed);
            }

            if (col.gameObject.name == "Racket")
            {
                _directionY *= -1f;
                _rb.velocity = new Vector2(_directionX * Speed, _directionY * Speed);
            }
        }
    }
}