using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput_Mouse : MonoBehaviour
{
    public Racket Racket;
    private Vector3 _oldMousePos;

    void Start()
    {
        _oldMousePos = GetMousePosition();
    }
    void FixedUpdate()
    {
        if (IsMouseMoves(_oldMousePos, GetMousePosition()))
        { 
            Racket.MoveRacketByMouse(GetMousePosition());
        }
        _oldMousePos = GetMousePosition();
        
    }

    Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    bool IsMouseMoves(Vector3 oldPos, Vector3 newPos)
    {
        return oldPos != newPos;
    }
}
