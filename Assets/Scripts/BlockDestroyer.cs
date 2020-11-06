using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    public GameController GameController;
    public Score Score;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Score.AddScore();
            GameController.BlockDestroyed();
            Destroy(gameObject);
        }
    }
}
