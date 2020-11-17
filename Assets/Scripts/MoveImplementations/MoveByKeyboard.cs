using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyboard : MonoBehaviour
{
    public float Speed = 10f;

    public GameObject Racket;
    public GameObject RacketPlayZone;

    private readonly UserInput_KeyBoard _userInputAxis = new UserInput_KeyBoard();

    public void MoveRacket()
    {
        var deltaX = _userInputAxis.GetHorizontalDirection();
        var deltaY = _userInputAxis.GetVerticalDirection();

        var movement = new Vector3(deltaX * Speed, deltaY * Speed);

        var xRacketExtents = Racket.GetComponent<BoxCollider2D>().bounds.extents.x;

        var yPlayZoneExtents = RacketPlayZone.GetComponent<BoxCollider2D>().bounds.extents.y;
        var xPlayZoneExtents = RacketPlayZone.GetComponent<BoxCollider2D>().bounds.extents.x;
        var PlayZoneCenter = RacketPlayZone.GetComponent<BoxCollider2D>().bounds.center;

        var yUpperPlayZoneBorder = PlayZoneCenter.y + yPlayZoneExtents;
        var yLowerPlayZoneBorder = PlayZoneCenter.y - yPlayZoneExtents;
        var xRightPlayZoneBorder = PlayZoneCenter.x + xPlayZoneExtents;
        var xLeftPlayZoneBorder = PlayZoneCenter.x - xPlayZoneExtents;

        movement = Vector3.ClampMagnitude(movement, Speed);
        movement *= Time.deltaTime;
        Racket.transform.Translate(movement);

        var allowedY = Mathf.Clamp(Racket.transform.position.y, yLowerPlayZoneBorder, yUpperPlayZoneBorder);
        var allowedX = Mathf.Clamp(Racket.transform.position.x, xLeftPlayZoneBorder + xRacketExtents,
            xRightPlayZoneBorder - xRacketExtents);
        Racket.transform.position = new Vector3(allowedX, allowedY);
    }
}
