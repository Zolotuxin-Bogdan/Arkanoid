using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public float XPosition { get; set; }
    public float YPosition { get; set; }
    public int BlockScoreCost { get; set; }

    public Block(float xPosition, float yPosition, int blockScoreCost)
    {
        XPosition = xPosition;
        YPosition = yPosition;
        BlockScoreCost = blockScoreCost;
    }
}
