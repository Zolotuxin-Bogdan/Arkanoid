using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance { get; private set; }
    public Level CurrentLevel { get; private set; }
    public Level CurrentLevelState { get; private set; } = new Level();

    public event Action GameFinishedEvent;

    public GameObject Block;
    public Score Score;

    private readonly Level_Initializer _initializer = new Level_Initializer();

    private int _blockCount = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void LoadLevel()
    {
        if (GameController.Instance.IsGameLoaded)
        {
            GenerateBlocks(CurrentLevelState);
            GameController.Instance.IsGameLoaded = false;
        }
        else
        {
            GenerateLvl();
        }
    }

    public void GenerateLvl()
    {
        CurrentLevel = _initializer.GetRandomLvl();
        CurrentLevelState.BlocksList = new List<Block>(CurrentLevel.BlocksList);
        GenerateBlocks(CurrentLevel);
    }

    public void RetryLvl()
    {
        GenerateBlocks(CurrentLevel);
    }

    public void DestroyBlock(GameObject receivedBlock)
    {
        if(!receivedBlock.CompareTag("Block")) return;

        Destroy(receivedBlock);
        _blockCount--;
        
        var receivedBlockId = receivedBlock.GetComponent<BlockId>().Id;

        var blockForRemove = CurrentLevelState.BlocksList.FirstOrDefault(t => t.Id == receivedBlockId);
        CurrentLevelState.BlocksList.Remove(blockForRemove);

        var amount = CurrentLevel.BlocksList
            .Where(t => t.Id == receivedBlockId)
            .Select(t => t.BlockScoreCost).FirstOrDefault();
        

        Score.AddAmountToScore(amount);

        if (_blockCount <= 0)
        {
            GameFinishedEvent?.Invoke();
        }
    }

    void GenerateBlocks(Level level)
    {
        foreach (var block in level.BlocksList)
        {
            var newInstance = Instantiate(Block, new Vector3(block.XPosition, block.YPosition), new Quaternion(0, 0, 0, 0));
            newInstance.GetComponent<BlockId>().Id = block.Id;
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
            GameFinishedEvent?.Invoke();
        }
    }

    public void SetCurrentLevel(Level level)
    {
        CurrentLevel = level;
    }

    public void SetCurrentLevelState(Level level)
    {
        CurrentLevelState = level;
    }
}
