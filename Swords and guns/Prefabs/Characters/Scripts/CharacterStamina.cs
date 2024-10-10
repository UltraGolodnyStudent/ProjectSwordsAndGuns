using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStamina : MonoBehaviour
{
    public bool IsTired { get; private set; } = false;

    private CharacterStats _characterStats;
    private Movement _movement;
    private float _maxStamina;
    private float _currentStamina;

    #region INITIALIZE
    public void Initialize()
    {
        _movement = GetComponent<Movement>();
        _characterStats = GetComponent<CharacterStats>();
        UpdateStamina();
    }
    #endregion
    private void FixedUpdate()
    {
        GiveStamina(0.1f);
        if (_movement.IsStanding)
            GiveStamina(0.2f);
        else if (_movement.IsWalking)
            GiveStamina(0.1f);
        else if (_movement.IsRunning)
            TakeStamina(0.4f);

        if (IsTired && _currentStamina > _maxStamina/5) 
            IsTired = false;
    }

    #region PUBLIC
    public void UpdateStamina() // если изменить выносливость и пр.
    {
        _maxStamina = _characterStats.GetMaxStamina();
        _currentStamina = _maxStamina;
    }
    public float GetCurrentStamina()
    {
        return _currentStamina;
    }
    public float GetMaxStamina()
    {
        return _maxStamina;
    }
    public void TakeStamina(float staminaTaken)
    {
        if (!IsTired)
        {
            if (_currentStamina >= staminaTaken)
                _currentStamina -= staminaTaken;
            else
            {
                _currentStamina = 0;
                IsTired = true;
            }

            if (_currentStamina <= 0)
                IsTired = true;
        }
    }
    public void GiveStamina(float staminaGiven)
    {
        _currentStamina += staminaGiven;
        if (_currentStamina > _maxStamina)
            _currentStamina = _maxStamina;
    }
    #endregion
}
