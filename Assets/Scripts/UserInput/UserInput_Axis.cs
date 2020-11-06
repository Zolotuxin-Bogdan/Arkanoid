using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput_Axis : MonoBehaviour
{
    public Racket Racket;
    void FixedUpdate()
    {
        Racket.MoveRacketByAxis(GetAxisDirection());
    }

    float GetAxisDirection()
    {
        return Input.GetAxisRaw("Horizontal");
    }
}
