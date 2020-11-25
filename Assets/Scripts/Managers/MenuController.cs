using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject SettingsCanvas;
    public GameObject MenuCanvas;
    public GameObject LoadGameCanvas;

    public StorageProvider StorageProvider;

    void Start()
    {

    }
    public void GoToSettingsFromMenu()
    {
        SettingsCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }

    public void GoToMenuFromSettings()
    {
        SettingsCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    public void ShowLoadGameCanvas()
    {
        LoadGameCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }

    public void GoToMenuFromLoadGamesList()
    {
        LoadGameCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }




}
