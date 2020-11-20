using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public Level Level { get; set; }
    public Level LevelState { get; set; }

    public int GlobalScore { get; set; }
    public int LocalScore { get; set; }

    public Vector3 BallPosition { get; set; }
    public Vector2 BallMovement { get; set; }

    public Vector3 RacketPosition { get; set; }
}
