using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    private int _currentExperience, 
        _pointCount = ScalingData.BasePointCount, // ÔÓËÌÚ˚ Ì‡ ‡ÒÔÂ‰ÂÎÂÌËÂ ÒÚ‡ÚÓ‚
        _level—ount = ScalingData.Baselevel—ount; // ÛÓ‚ÂÌ¸

    public void AddExperience(int addedExperience)
    {
        _currentExperience += addedExperience;

        while (_currentExperience >= GetMaxExperience()) // ÂÒÎË ÔÓÓ„ Ï‡ÍÒËÏ‡Î¸ÌÓ„Ó ÓÔ˚Ú‡ ÔÂ‚˚¯ÂÌ
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
        _level—ount++;
        _pointCount++;
    }

    private int GetMaxExperience()
    {
        return ScalingData.BasemaxExperience + _level—ount * ScalingData.ExperienceLevelFactor;
    }
}
