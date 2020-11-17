using System;
using System.Collections.Generic;
using UnityEngine;

public class Level_Initializer
{
    private readonly List<Level> _listOfLevels = new List<Level>();
    private readonly Level _level1 = new Level();
    private readonly Level _level2 = new Level();

    public Level_Initializer()
    {
        _level1.BlocksList = new List<Block>
        {
            new Block(-9f, 2f, 1), new Block(-7f, 2f, 1), 
            new Block(-5f, 2f, 1), new Block(-2f, 2f, 1),
            new Block(0f, 2f, 1), new Block(2f, 2f, 1),
            new Block(5f, 2f, 1), new Block(7f, 2f, 1),
            new Block(9f,2f, 1), new Block(-8f, 1f, 1),
            new Block(-6f, 1f, 1), new Block(-3f, 1f, 1),
            new Block(0f, 1f, 1), new Block(3f, 1f, 1),
            new Block(6f, 1f, 1), new Block(8f, 1f, 1)
        };

        _listOfLevels.Add(_level1);
        ///////////////////////////////////////////////////////////////////////////////
        
        _level2.BlocksList = new List<Block>
        {
            new Block(-5f, 3f, 2), new Block(-3f, 3f, 2),
            new Block(-1f, 3f, 2), new Block(1f, 3f, 2),
            new Block(3f, 3f, 2), new Block(5f, 3f, 2),
            new Block(-8f, 2f, 2), new Block(-6f, 2f, 2),
            new Block(-4f, 2f, 2), new Block(-2f, 2f, 2),
            new Block(0f, 2f, 2), new Block(2f, 2f, 2),
            new Block(4f, 2f, 2), new Block(6f, 2f, 2),
            new Block(8f,2f, 2), new Block(-9f, 1f, 2),
            new Block(-5f, 1f, 2), new Block(-3f, 1f, 2),
            new Block(0f, 1f, 2), new Block(3f, 1f, 2),
            new Block(5f, 1f, 2), new Block(9f, 1f, 2)
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
