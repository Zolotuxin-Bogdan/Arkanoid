using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private float _speed = 50f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveRacketByMouse(Vector3 mousePos)
    {
        mousePos.y = transform.position.y;
        mousePos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, mousePos, _speed * Time.deltaTime);
    }

    public void MoveRacketByAxis(float axisDirection)
    {
        rb.velocity = Vector2.right * axisDirection * 10f;
    }
}
