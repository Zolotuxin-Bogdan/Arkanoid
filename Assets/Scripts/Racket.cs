using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private Vector3 _mousePos;
    private float _speed = 50f;

    void FixedUpdate()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.y = transform.position.y;
        _mousePos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, _mousePos, _speed * Time.deltaTime);
    }

    /*void FixedUpdate()
    {
        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * 10f;
    }*/
}
