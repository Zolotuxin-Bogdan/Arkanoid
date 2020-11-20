using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject SettingsCanvas;
    public GameObject MenuCanvas;
    public GameObject LoadGameButton;

    public StorageProvider StorageProvider;

    void Start()
    {
        /*if (StorageProvider.LoadGameState() == default)
        {
            LoadGameButton.SetActive(false);
        }
        else
        {
            LoadGameButton.SetActive(true);
        }*/
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




}
