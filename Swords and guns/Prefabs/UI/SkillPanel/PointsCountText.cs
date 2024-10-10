using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCountText : MonoBehaviour
{
    [SerializeField] GameObject _strengthPanel;

    private int _pointsCount;

    private void Update()
    {
        _pointsCount = _strengthPanel.GetComponent<Strength_panel>().GetPoints();

        GetComponent<TextMeshProUGUI>().text = _pointsCount.ToString();
    }
}
