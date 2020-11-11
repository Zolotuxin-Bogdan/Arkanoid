using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByMouse : MonoBehaviour
{
    public float Speed = 40f;
    
    public GameObject Racket;
    public GameObject RacketPlayZone;

    private Vector3 _mousePos;
    private readonly UserInput_Mouse _userInputMouse = new UserInput_Mouse();

    public void MoveRacket()
    {
        _mousePos = _userInputMouse.GetMousePosition();

        var yHalfExtents = RacketPlayZone.GetComponent<BoxCollider>().bounds.extents.y;
        var yCenter = RacketPlayZone.GetComponent<BoxCollider>().bounds.center;

        var yUpper = yCenter.y + yHalfExtents;
        var yLower = yCenter.y - yHalfExtents;
        if (_mousePos.y > yUpper)
        {
            _mousePos.y = yUpper;
        }
        if (_mousePos.y < yLower)
        {
            _mousePos.y = yLower;
        }
        _mousePos.z = Racket.transform.position.z;
        Racket.transform.position = Vector3.MoveTowards(Racket.transform.position, _mousePos, Speed * Time.deltaTime);
    }

}
