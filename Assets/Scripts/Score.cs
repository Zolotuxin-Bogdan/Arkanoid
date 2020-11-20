using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Txt;
    public int GlobalScore { get; private set; } = 0;
    public int LocalScore { get; private set; } = 0;

    public void SetScoreToUI()
    {
        Txt.text = "Score: " + (GlobalScore + LocalScore);
    }

    public void AddAmountToScore(int amount)
    {
        LocalScore += amount;
        SetScoreToUI();
    }

    public void ResetLvlScore()
    {
        LocalScore = 0;
    }

    public void SaveLvlScoreToGlobalScore()
    {
        GlobalScore += LocalScore;
        ResetLvlScore();
        SetScoreToUI();
    }

    public void SetGlobalScore(int value)
    {
        GlobalScore = value;
        SetScoreToUI();
    }

    public void SetLocalScore(int value)
    {
        LocalScore = value;
        SetScoreToUI();
    }
}
