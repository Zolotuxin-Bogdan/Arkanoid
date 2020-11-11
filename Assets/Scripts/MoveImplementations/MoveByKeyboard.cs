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

        var yHalfExtents = RacketPlayZone.GetComponent<BoxCollider>().bounds.extents.y;
        var yCenter = RacketPlayZone.GetComponent<BoxCollider>().bounds.center;

        var yUpper = yCenter.y + yHalfExtents;
        var yLower = yCenter.y - yHalfExtents;

        movement = Vector3.ClampMagnitude(movement, Speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);

        var allowedY = Mathf.Clamp(Racket.transform.position.y, yLower, yUpper);
        Racket.transform.position = new Vector3(Racket.transform.position.x, allowedY);
    }
}
