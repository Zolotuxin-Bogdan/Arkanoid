﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject RacketSkin;
    public StorageProvider StorageProvider;
    private RacketColor _racketColor;

    private Image _spriteImage;
    private Color _newColor;

    
    void Start()
    {
        _spriteImage = RacketSkin.GetComponent<Image>();
        _newColor.r = 255;
        _newColor.g = 255;
        _newColor.b = 255;
        _newColor.a = 255;
    }

    void Update()
    {
        _spriteImage.color = _newColor;
    }

    void OnDestroy()
    {
        //RacketColor.RedColor = _spriteImage.color.r;
        //RacketColor.GreenColor = _spriteImage.color.g;
        //RacketColor.BlueColor = _spriteImage.color.b;
        StorageProvider.SaveRacketColor();
    }

    public void Red_Slider_Changed(float newValue)
    {
        _newColor = new Color(newValue, _spriteImage.color.g, _spriteImage.color.b);
    }
    public void Green_Slider_Changed(float newValue)
    {
        _newColor = new Color(_spriteImage.color.r, newValue, _spriteImage.color.b);
    }
    public void Blue_Slider_Changed(float newValue)
    {
        _newColor = new Color(_spriteImage.color.r, _spriteImage.color.g, newValue);
    }
}
