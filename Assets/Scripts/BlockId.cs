﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockId : MonoBehaviour
{
    public int Id;
    void Awake()
    {
        Id = BlockManager.Instance.BlockCount;
    }

}
