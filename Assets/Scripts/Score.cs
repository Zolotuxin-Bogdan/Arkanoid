using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Txt;
    private int _score = 0;

    void FixedUpdate()
    {
        Txt.text = "Score: " + _score;
    }

    public void AddScore()
    {
        _score += 1;
    }
}
