using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public static bool GameLoaded = false;

    ////////////////////////////////////////////////
    //// Scene Loading
    ////////////////////////////////////////////////
    public void LoadNewGameScene()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void LoadGameSaveScene()
    {
        SceneManager.LoadScene("Game Scene");
        GameLoaded = true;
        
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
