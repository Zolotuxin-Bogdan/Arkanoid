using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput_Mouse : MonoBehaviour
{
    public Racket Racket;

    void FixedUpdate()
    {
        Racket.MoveRacketByMouse(GetMousePosition());
    }

    Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
