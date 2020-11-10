using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    ////////////////////////////////////////////////
    //// Scene Loading
    ////////////////////////////////////////////////
    public void LoadNewGameScene()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    ////////////////////////////////////////////////
    
    public void ExitGame()
    {
        Application.Quit();
    }

    ////////////////////////////////////////////////
    //// InGame Interactions
    ////////////////////////////////////////////////
    public void LoadNextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RetryLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    ////////////////////////////////////////////////

}
