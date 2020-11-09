using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int _blockCounter;

    public GameObject WinCanvas;
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

        if (Input.GetKeyDown("x"))
        {
            DestroyAllBlocks();
        }
    }

    public void BlockDestroyed()
    {
        _blockCounter -= 1;
    }

    void GameFinished()
    {
        Time.timeScale = 0;
        WinCanvas.SetActive(true);
    }

    void DestroyAllBlocks()
    {
        var blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (var block in blocks)
        {
            Destroy(block);
        }

        _blockCounter = 0;
    }
}
