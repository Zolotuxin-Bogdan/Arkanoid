using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput_KeyBoard
{
    public float GetHorizontalDirection()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public float GetVerticalDirection()
    {
        return Input.GetAxisRaw("Vertical");
    }

    public bool Is_X_Pressed()
    {
        return Input.GetKeyDown("x");
    }
}
