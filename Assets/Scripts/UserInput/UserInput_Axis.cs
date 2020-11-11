using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput_Axis
{
    public float GetHorizontalDirection()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public float GetVerticalDirection()
    {
        return Input.GetAxisRaw("Vertical");
    }
}
