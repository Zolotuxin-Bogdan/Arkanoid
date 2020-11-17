using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Txt;
    private int _globalScore = 0;
    private int _levelScore = 0;

    public void SetScoreToUI()
    {
        Txt.text = "Score: " + (_globalScore + _levelScore);
    }

    public void AddAmountToScore()
    {
        _levelScore += 1;
        SetScoreToUI();
    }

    public void ResetLvlScore()
    {
        _levelScore = 0;
    }

    public void SaveLvlScoreToGlobalScore()
    {
        _globalScore += _levelScore;
        ResetLvlScore();
        SetScoreToUI();
    }
}
