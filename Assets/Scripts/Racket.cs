using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private float _speed = 50f;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;

    private Color _colorFromSettings;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        _colorFromSettings = new Color(RacketColor.RedColor, RacketColor.GreenColor, RacketColor.BlueColor, 255);

        _sprite.color = _colorFromSettings;
    }

    public void MoveRacketByMouse(Vector3 mousePos)
    {
        mousePos.y = transform.position.y;
        mousePos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, mousePos, _speed * Time.deltaTime);
    }

    public void MoveRacketByAxis(float axisDirection)
    {
        _rb.velocity = Vector2.right * axisDirection * 10f;
    }
}
