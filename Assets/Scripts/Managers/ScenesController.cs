using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    private readonly SessionStorage _sessionStorage = SessionStorage.Instance;
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
        _sessionStorage.GameLoaded = true;
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
