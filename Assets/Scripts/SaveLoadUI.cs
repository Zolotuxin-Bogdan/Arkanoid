using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUI : MonoBehaviour
{
    public Text CellOneDateTimeText;
    public Text CellTwoDateTimeText;
    public Text CellThreeDateTimeText;
    public Button CellOneButton;
    public Button CellTwoButton;
    public Button CellThreeButton;

    public StorageProvider StorageProvider;

    private List<Text> _dateTimeTextsList = new List<Text>();
    private List<Button> _buttonsList = new List<Button>();
    void Awake()
    {
        _dateTimeTextsList.Add(CellOneDateTimeText);
        _dateTimeTextsList.Add(CellTwoDateTimeText);
        _dateTimeTextsList.Add(CellThreeDateTimeText);

        _buttonsList.Add(CellOneButton);
        _buttonsList.Add(CellTwoButton);
        _buttonsList.Add(CellThreeButton);
    }

    public void LoadDateTimeToUI()
    {
        if (StorageProvider.LoadGameCellsDict() == null)
        {
            foreach (var button in _buttonsList)
            {
                if (button != null)
                {
                    button.interactable = false;
                }
            }

            foreach (var dateTimeText in _dateTimeTextsList)
            {
                dateTimeText.text = "Empty";
            }
            return;
        }
        var gameCellsDict = StorageProvider.LoadGameCellsDict();
        for (var i = 0; i < _dateTimeTextsList.Count; i++)
        {
            if (gameCellsDict.SaveCells.ContainsKey(i))
            {
                _dateTimeTextsList[i].text = gameCellsDict.SaveCells[i].TimeStamp.ToString();
            }
            else
            {
                _dateTimeTextsList[i].text = "Empty";
                if (_buttonsList[i] != null)
                {
                    _buttonsList[i].interactable = false;
                }
            }
        }
    }
}
