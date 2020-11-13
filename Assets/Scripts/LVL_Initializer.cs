using System;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Initializer
{
    private readonly List<LVL> _listOfLevels = new List<LVL>();
    private readonly LVL _lvl1 = new LVL();
    private readonly LVL _lvl2 = new LVL();

    public LVL_Initializer()
    {
        _lvl1.BlocksList = new List<(int, int)>
        {
            (-9, 2), (-7, 2), (-5, 2), (-2, 2), (0, 2), (2, 2), (5, 2), (7, 2), (9,2),
            (-8, 1), (-6, 1), (-3, 1), (0, 1), (3, 1), (6, 1), (8, 1)
        };

        _listOfLevels.Add(_lvl1);
        ///////////////////////////////////////////////////////////////////////////////
        
        _lvl2.BlocksList = new List<(int, int)>
        {
            (-5, 3), (-3, 3), (-1, 3), (1, 3), (3, 3), (5, 3),
            (-8, 2), (-6, 2), (-4, 2), (-2, 2), (0, 2), (2, 2), (4, 2), (6, 2), (8,2),
            (-9, 1), (-5, 1), (-3, 1), (0, 1), (3, 1), (5, 1), (9, 1)
        };

        _listOfLevels.Add(_lvl2);

    }
    public LVL GetRandomLvl()
    {
        var random = new System.Random();
        var index = random.Next(_listOfLevels.Count);
        return _listOfLevels[index];
    }

}
