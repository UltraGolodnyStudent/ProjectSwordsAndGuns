using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_panel : MonoBehaviour
{
    private GameObject _skillPanel;
    private GameObject _strengthPanel;
    private GameObject _endurancePanel;
    private GameObject _masteryPanel;
    private GameObject _magicPanel;

    #region INITIALIZE
    public void Initialize(List<Button> buttonlList, List<GameObject> panelList)
    {
        _skillPanel = gameObject;
        _strengthPanel = panelList[0];
        _endurancePanel = panelList[1];
        _masteryPanel = panelList[2];
        _magicPanel = panelList[3];

        buttonlList[0].onClick.AddListener(StrengthButtonClick);
        buttonlList[1].onClick.AddListener(EnduranceButtonClick);
        buttonlList[2].onClick.AddListener(MasteryButtonClick);
        buttonlList[3].onClick.AddListener(MagicButtonClick);
    }
    #endregion

    private void StrengthButtonClick()
    {
        _skillPanel.SetActive(false);
        _strengthPanel.SetActive(true);
    }
    private void EnduranceButtonClick()
    {
        _skillPanel.SetActive(false);
        _endurancePanel.SetActive(true);
    }
    private void MasteryButtonClick()
    {
        _skillPanel.SetActive(false);
        _masteryPanel.SetActive(true);
    }
    private void MagicButtonClick()
    {
        _skillPanel.SetActive(false);
        _magicPanel.SetActive(true);
    }
}
