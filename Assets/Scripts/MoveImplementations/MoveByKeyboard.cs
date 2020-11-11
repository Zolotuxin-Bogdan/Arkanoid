using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyboard : MonoBehaviour
{
    public float Speed = 10f;

    public GameObject Racket;
    public GameObject RacketPlayZone;

    private readonly UserInput_Axis _userInputAxis = new UserInput_Axis();
    private CharacterController _characterController;

    void Start()
    {
        _characterController = Racket.GetComponent<CharacterController>();
    }

    public void MoveRacket()
    {
        var deltaX = _userInputAxis.GetHorizontalDirection();
        var deltaY = _userInputAxis.GetVerticalDirection();

        var movement = new Vector3(deltaX * Speed, deltaY * Speed);

        var xRacketExtents = Racket.GetComponent<BoxCollider>().bounds.extents.x;

        var yPlayZoneExtents = RacketPlayZone.GetComponent<BoxCollider>().bounds.extents.y;
        var xPlayZoneExtents = RacketPlayZone.GetComponent<BoxCollider>().bounds.extents.x;
        var PlayZoneCenter = RacketPlayZone.GetComponent<BoxCollider>().bounds.center;

        var yUpperPlayZoneBorder = PlayZoneCenter.y + yPlayZoneExtents;
        var yLowerPlayZoneBorder = PlayZoneCenter.y - yPlayZoneExtents;
        var xRightPlayZoneBorder = PlayZoneCenter.x + xPlayZoneExtents;
        var xLeftPlayZoneBorder = PlayZoneCenter.x - xPlayZoneExtents;

        movement = Vector3.ClampMagnitude(movement, Speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);

        var allowedY = Mathf.Clamp(Racket.transform.position.y, yLowerPlayZoneBorder, yUpperPlayZoneBorder);
        var allowedX = Mathf.Clamp(Racket.transform.position.x, xLeftPlayZoneBorder + xRacketExtents,
            xRightPlayZoneBorder - xRacketExtents);
        Racket.transform.position = new Vector3(allowedX, allowedY);
    }
}
