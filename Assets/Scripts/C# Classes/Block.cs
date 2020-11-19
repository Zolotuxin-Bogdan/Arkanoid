using System.Threading;

public class Block
{
    public int Id { get; set; }
    public float XPosition { get; set; }
    public float YPosition { get; set; }
    public int BlockScoreCost { get; set; }

    public Block(int id, float xPosition, float yPosition, int blockScoreCost)
    {
        Id = id;
        XPosition = xPosition;
        YPosition = yPosition;
        BlockScoreCost = blockScoreCost;
    }

}
