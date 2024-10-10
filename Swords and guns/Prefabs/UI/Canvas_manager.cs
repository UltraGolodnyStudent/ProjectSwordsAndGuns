using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_manager : MonoBehaviour
{
    private GameObject _skillPanel;
    private bool _isActive;
    private List<GameObject> _panelList;

    public void Initialize(GameObject skillPanel, List<GameObject> panelList)
    {
        _skillPanel = skillPanel;
        _panelList = panelList;
    }

    private void Update()
    {
        TabKeyDown();
    }

    private void TabKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!_isActive)
            {
                _skillPanel.SetActive(true);
                _isActive = true;
            }
            else
            {
                _skillPanel.SetActive(false);
                _isActive = false;
            }

            foreach (GameObject panel in _panelList)
                panel.SetActive(false);
        }
    }
}
