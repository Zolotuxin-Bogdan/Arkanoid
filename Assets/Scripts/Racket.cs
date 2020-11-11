using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Color _colorFromSettings;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _colorFromSettings = new Color(RacketColor.RedColor, RacketColor.GreenColor, RacketColor.BlueColor, 255);

        _sprite.color = _colorFromSettings;
    }
}
