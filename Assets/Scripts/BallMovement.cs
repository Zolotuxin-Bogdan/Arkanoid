using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float Speed = 7f;
    private float _directionY = 1f;
    private float _directionX = 1f;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = (Vector2.up + Vector2.right) * Speed * 1f;
    }

    void FixedUpdate()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(_directionX * Speed, _directionY * Speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Border Top" || col.gameObject.tag == "Block")
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