using System.Collections.Generic;

public class Level_Initializer
{
    private readonly List<Level> _listOfLevels = new List<Level>();
    private readonly Level _level1 = new Level();
    private readonly Level _level2 = new Level();

    public Level_Initializer()
    {
        _level1.BlocksList = new List<Block>
        {
            new Block(0, -9f, 2f, 1), new Block(1, -7f, 2f, 1), 
            new Block(2, -5f, 2f, 1), new Block(3, -2f, 2f, 1),
            new Block(4, 0f, 2f, 1), new Block(5, 2f, 2f, 1),
            new Block(6, 5f, 2f, 1), new Block(7, 7f, 2f, 1),
            new Block(8, 9f,2f, 1), new Block(9, -8f, 1f, 1),
            new Block(10, -6f, 1f, 1), new Block(11, -3f, 1f, 1),
            new Block(12, 0f, 1f, 1), new Block(13, 3f, 1f, 1),
            new Block(14, 6f, 1f, 1), new Block(15, 8f, 1f, 1)
        };

        _listOfLevels.Add(_level1);
        ///////////////////////////////////////////////////////////////////////////////
        
        _level2.BlocksList = new List<Block>
        {
            new Block(0, -5f, 3f, 2), new Block(1, -3f, 3f, 2),
            new Block(2, -1f, 3f, 2), new Block(3, 1f, 3f, 2),
            new Block(4, 3f, 3f, 2), new Block(5, 5f, 3f, 2),
            new Block(6, -8f, 2f, 2), new Block(7, -6f, 2f, 2),
            new Block(8, -4f, 2f, 2), new Block(9, -2f, 2f, 2),
            new Block(10, 0f, 2f, 2), new Block(11, 2f, 2f, 2),
            new Block(12, 4f, 2f, 2), new Block(13, 6f, 2f, 2),
            new Block(14, 8f,2f, 2), new Block(15, -9f, 1f, 2),
            new Block(16, -5f, 1f, 2), new Block(17, -3f, 1f, 2),
            new Block(18, 0f, 1f, 2), new Block(19, 3f, 1f, 2),
            new Block(20, 5f, 1f, 2), new Block(21, 9f, 1f, 2)
        };

        _listOfLevels.Add(_level2);

    }
    public Level GetRandomLvl()
    {
        var random = new System.Random();
        var index = random.Next(_listOfLevels.Count);
        return _listOfLevels[index];
    }

}
