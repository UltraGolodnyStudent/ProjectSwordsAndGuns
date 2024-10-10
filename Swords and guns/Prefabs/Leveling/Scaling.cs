using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    private int _currentExperience, 
        _pointCount = ScalingData.BasePointCount, // ������ �� ������������� ������
        _level�ount = ScalingData.Baselevel�ount; // �������

    public void AddExperience(int addedExperience)
    {
        _currentExperience += addedExperience;

        while (_currentExperience >= GetMaxExperience()) // ���� ����� ������������� ����� ��������
            NewLevel();
    }
    public void TakePoints(int takedPoints)
    {
        _pointCount -= takedPoints;
    }
    public int GetPoints() => _pointCount;

    private void NewLevel()
    {
        _currentExperience -= GetMaxExperience();
        _level�ount++;
        _pointCount++;
    }

    private int GetMaxExperience()
    {
        return ScalingData.BasemaxExperience + _level�ount * ScalingData.ExperienceLevelFactor;
    }
}
