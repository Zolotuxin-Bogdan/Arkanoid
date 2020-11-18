using UnityEngine;

public class UserInput_Mouse
{
    public Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
