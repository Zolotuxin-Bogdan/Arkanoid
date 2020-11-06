using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int _blockCounter;
    void Start()
    {
        _blockCounter = GameObject.FindGameObjectsWithTag("Block").Length;
    }
    void Update()
    {
        if (_blockCounter <= 0)
        {
            GameFinished();
        }
    }

    public void BlockDestroyed()
    {
        _blockCounter -= 1;
    }

    void GameFinished()
    {
        Time.timeScale = 0;
        Debug.Log("LEVEL COMPLETE");
    }
}
