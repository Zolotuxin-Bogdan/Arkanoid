using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllScenesAndMenu : MonoBehaviour
{
	public void NewGameLoadScene()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadNextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RetryLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
