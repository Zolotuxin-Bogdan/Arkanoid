using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject SettingsCanvas;
    public GameObject MenuCanvas;


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
