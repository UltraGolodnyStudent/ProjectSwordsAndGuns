using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterHealth : MonoBehaviour
{
    private CharacterStats _characterStats;
    private float _maxHealth;
    private float _currentHealth;

    #region INITIALIZE
    public void Initialize()
    {
        _characterStats = GetComponent<CharacterStats>();
        UpdateHealth();
    }
    #endregion

    #region PUBLIC
    public void UpdateHealth() // если изменить силу и пр.
    {
        _maxHealth = _characterStats.GetMaxHP();
        _currentHealth = _maxHealth;
    }
    public void GetDamage(GameObject damagedObject, GameObject damageCauser, float damageTaken)
    {
        if(damagedObject == gameObject)
        {
            _currentHealth -= damageTaken;

            if (_currentHealth <= 0)
                EventBus.OnEnemyDied(gameObject, damageCauser);
        }
    }
    public void Heal(float healGiven)
    {
        _currentHealth += healGiven;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }
    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
    public float GetMaxHealth()
    {
        return _maxHealth;
    }
    #endregion

    virtual protected void Death(GameObject diedObject, GameObject diedCauser)
    {
        if(diedObject == gameObject)
            Debug.Log("Смерть");
    }

    private void OnEnable()
    {
        EventBus.AnyDamage += GetDamage;
        EventBus.EnemyDied += Death;
    }
    private void OnDisable()
    {
        EventBus.AnyDamage -= GetDamage;
        EventBus.EnemyDied -= Death;
    }
}
