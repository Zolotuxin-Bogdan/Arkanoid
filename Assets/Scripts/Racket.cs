using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private float _speed = 50f;

    public void MoveRacketByMouse(Vector3 mousePos)
    {
        mousePos.y = transform.position.y;
        mousePos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, mousePos, _speed * Time.deltaTime);
    }


    /*void FixedUpdate()
    {
        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * 10f;
    }*/
}
