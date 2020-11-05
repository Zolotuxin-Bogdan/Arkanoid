using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            Time.timeScale = 0;
            Debug.Log("LEVEL COMPLETE");
        }
    }
}
