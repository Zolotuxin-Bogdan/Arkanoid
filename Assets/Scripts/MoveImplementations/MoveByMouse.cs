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

        var xRacketExtents = Racket.GetComponent<BoxCollider>().bounds.extents.x;


        var yPlayZoneExtents = RacketPlayZone.GetComponent<BoxCollider>().bounds.extents.y;
        var xPlayZoneExtents = RacketPlayZone.GetComponent<BoxCollider>().bounds.extents.x;
        var PlayZoneCenter = RacketPlayZone.GetComponent<BoxCollider>().bounds.center;

        var yUpperPlayZoneBorder = PlayZoneCenter.y + yPlayZoneExtents;
        var yLowerPlayZoneBorder = PlayZoneCenter.y - yPlayZoneExtents;
        var xRightPlayZoneBorder = PlayZoneCenter.x + xPlayZoneExtents;
        var xLeftPlayZoneBorder = PlayZoneCenter.x - xPlayZoneExtents;

        if (_mousePos.y > yUpperPlayZoneBorder)
        {
            _mousePos.y = yUpperPlayZoneBorder;
        }
        if (_mousePos.y < yLowerPlayZoneBorder)
        {
            _mousePos.y = yLowerPlayZoneBorder;
        }

        if (_mousePos.x - xRacketExtents < xLeftPlayZoneBorder)
        {
            _mousePos.x = xLeftPlayZoneBorder + xRacketExtents;
        }
        if (_mousePos.x + xRacketExtents > xRightPlayZoneBorder)
        {
            _mousePos.x = xRightPlayZoneBorder - xRacketExtents;
        }

        _mousePos.z = Racket.transform.position.z;
        Racket.transform.position = Vector3.MoveTowards(Racket.transform.position, _mousePos, Speed * Time.deltaTime);
    }

}
