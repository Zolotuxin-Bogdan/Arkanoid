using System;
using System.Linq;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance = null;

    //public delegate void GameFinishedHandler();
    public event Action GameFinishedEvent;

    public GameObject Block;
    public Score Score;

    private readonly Level_Initializer _initializer = new Level_Initializer();

    public int BlockCount = 0;
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
        //DontDestroyOnLoad(gameObject);
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
        if(!receivedBlock.CompareTag("Block")) return;

        Destroy(receivedBlock);
        BlockCount--;
        var receivedBlockId = receivedBlock.GetComponent<BlockId>().Id;
        
        var amount = _currentLvl.BlocksList
            .Where(t => t.Id == receivedBlockId)
            .Select(t => t.BlockScoreCost).FirstOrDefault();
        Score.AddAmountToScore(amount);

        if (BlockCount <= 0)
        {
            GameFinishedEvent?.Invoke();
        }
    }

    void GenerateBlocks(Level level)
    {
        foreach (var block in level.BlocksList)
        {
            Instantiate(Block, new Vector3(block.XPosition, block.YPosition), new Quaternion(0, 0, 0, 0));
            BlockCount++;
        }
    }

    public void DestroyAllBlocks()
    {
        var blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (var block in blocks)
        {
            Destroy(block);
        }

        BlockCount = 0;
        if (BlockCount <= 0)
        {
            GameFinishedEvent?.Invoke();
        }
    }
}
