using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Txt;
    private int _globalScore = 0;
    private int _lvlScore = 0;

    void FixedUpdate()
    {
        Txt.text = "Score: " + (_globalScore + _lvlScore);
    }

    public void AddScore()
    {
        _lvlScore += 1;
    }

    public void ResetLvlScore()
    {
        _lvlScore = 0;
    }

    public void SaveLvlScoreToGlobalScore()
    {
        _globalScore += _lvlScore;
        ResetLvlScore();
    }
}
