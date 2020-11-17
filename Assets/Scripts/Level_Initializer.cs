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
        _level1.BlocksList = new List<(int, int)>
        {
            (-9, 2), (-7, 2), (-5, 2), (-2, 2), (0, 2), (2, 2), (5, 2), (7, 2), (9,2),
            (-8, 1), (-6, 1), (-3, 1), (0, 1), (3, 1), (6, 1), (8, 1)
        };

        _listOfLevels.Add(_level1);
        ///////////////////////////////////////////////////////////////////////////////
        
        _level2.BlocksList = new List<(int, int)>
        {
            (-5, 3), (-3, 3), (-1, 3), (1, 3), (3, 3), (5, 3),
            (-8, 2), (-6, 2), (-4, 2), (-2, 2), (0, 2), (2, 2), (4, 2), (6, 2), (8,2),
            (-9, 1), (-5, 1), (-3, 1), (0, 1), (3, 1), (5, 1), (9, 1)
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
