using UnityEngine;

public class SaveGameButton : MonoBehaviour
{
    public void SaveClick(int saveCellIndex)
    {
        GameController.Instance.SaveGame(saveCellIndex);
    }

    public void LoadClick(int loadCellIndex)
    {
        var _sessionStorage = SessionStorage.Instance;
        _sessionStorage.LoadCellIndex = loadCellIndex;
    }
}

