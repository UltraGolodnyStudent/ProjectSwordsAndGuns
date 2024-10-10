using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength_panel : MonoBehaviour
{
    private GameObject _mainCharacter;
    private CharacterStats _characterStats;
    private PlayerHealth _playerHealth;
    private PlayerMovement _playerMovement;
    private Scaling _scaling;

    private int _pointCount;
    private int _armCount = 0;
    private int _legCount = 0;
    private int _coreCount = 0;

    #region INITIALIZATION
    public void Initialize(GameObject mainCharacter)
    {
        _mainCharacter = mainCharacter;
        _characterStats = _mainCharacter.GetComponent<CharacterStats>();
        _playerHealth = _mainCharacter.GetComponent<PlayerHealth>();
        _playerMovement = _mainCharacter.GetComponent<PlayerMovement>();
        _scaling = _mainCharacter.GetComponent<Scaling>();
    }

    private void OnEnable()
    {
        _pointCount = _scaling.GetPoints();
    }
    #endregion

    #region PUBLIC
    public void AddArmStrength()
    {
        if(_pointCount > 0)
        {
            _armCount++;
            _pointCount--;
        }     
    }
    public void AddLegStrength()
    {
        if (_pointCount > 0)
        {
            _legCount++;
            _pointCount--;
        }
    }
    public void AddCoreStrength()
    {
        if (_pointCount > 0)
        {
            _coreCount++;
            _pointCount--;
        }
    }
    public void Apply()
    {
        _characterStats.AddStat(0, _armCount);
        _characterStats.AddStat(1, _legCount);
        _characterStats.AddStat(2, _coreCount);

        _armCount = _legCount = _coreCount = 0;

        _playerHealth.UpdateHealth();
        _playerMovement.UpdateSpeed();
        _scaling.TakePoints(_scaling.GetPoints() - _pointCount); // максимум поинтов минус те, что остались, итого получаем число отнятых поинтов
    }
    public void ClearButton()
    {
        _armCount = 0;
        _legCount = 0;
        _coreCount = 0;
    }
    public int GetPoints() => _pointCount;
    #endregion
}
