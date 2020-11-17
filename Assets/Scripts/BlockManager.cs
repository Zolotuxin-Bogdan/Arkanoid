using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance = null;

    public GameObject Block;
    public Score Score;
    public GameController GameController;

    private readonly Level_Initializer _initializer = new Level_Initializer();

    private int _blockCount = 0;
    private Level _currentLvl;

    void Awake()
    {
        if (Instance == null)
        { 
            Instance = this; 
        }
        else if (Instance == this)
        { 
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GenerateLvl();
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

    public void DestroyBlock(GameObject receivedBlock)
    {
        Destroy(receivedBlock);
        _blockCount--;

        var amount = from block in _currentLvl.BlocksList
            where block.XPosition.Equals(receivedBlock.transform.position.x) && block.YPosition.Equals(receivedBlock.transform.position.y)
            select block.BlockScoreCost;
        Score.AddAmountToScore(amount.First());

        if (_blockCount <= 0)
        {
            GameController.GameFinished();
        }
    }

    void GenerateBlocks(Level level)
    {
        foreach (var block in level.BlocksList)
        {
            Instantiate(Block, new Vector3(block.XPosition, block.YPosition), new Quaternion(0, 0, 0, 0));
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
        if (_blockCount <= 0)
        {
            GameController.GameFinished();
        }
    }
}
