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

    public bool IsKeyPressed(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }
}
