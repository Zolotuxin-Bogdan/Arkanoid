using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject Block;
    public Score Score;
    public GameController GameController;

    private readonly LVL_Initializer _initializer = new LVL_Initializer();

    private int _blockCount = 0;
    private LVL _currentLvl;

    void Start()
    {
        GenerateLvl();
    }

    void FixedUpdate()
    {
        if (_blockCount <= 0)
        {
            GameController.GameFinished();
        }

        if (Input.GetKeyDown("x"))
        {
            DestroyAllBlocks();
        }
    }
    public void GenerateLvl()
    {
        _currentLvl = _initializer.GetRandomLvl();
        GenerateBlocks(_currentLvl);
    }

    public void RetryLvl()
    {
        GenerateBlocks(_currentLvl);
    }

    public void DestroyBlock(GameObject block)
    {
        Destroy(block);
        _blockCount--;
        Score.AddScore();
    }

    void GenerateBlocks(LVL lvl)
    {
        foreach (var block in lvl.BlocksList)
        {
            Instantiate(Block, new Vector3(block.Item1, block.Item2), new Quaternion(0, 0, 0, 0));
            _blockCount++;
        }
    }

    public void DestroyAllBlocks()
    {
        var blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (var block in blocks)
        {
            Destroy(block);
        }

        _blockCount = 0;
    }
}
