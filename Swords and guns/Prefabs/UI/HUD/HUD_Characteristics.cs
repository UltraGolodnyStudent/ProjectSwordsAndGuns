using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD_Characteristics : MonoBehaviour
{
    private GameObject _mainCharacter;
    private Slider _hpBar;
    private Slider _stBar;
    private TextMeshProUGUI _hpText;
    private TextMeshProUGUI _stText;

    private float _currentHealth;
    private float _maxHealth;
    private float _maxStamina;
    private float _currentStamina;

    public void Initialize(GameObject mainCharacter, Slider hpBar, TextMeshProUGUI hpText, Slider stBar, TextMeshProUGUI stText)
    {
        _mainCharacter = mainCharacter;
        _hpBar = hpBar;
        _stBar = stBar;
        _hpText = hpText;
        _stText = stText;
    }
    private void Update()
    {
        _currentHealth = _mainCharacter.GetComponent<PlayerHealth>().GetCurrentHealth();
        _currentStamina = _mainCharacter.GetComponent<CharacterStamina>().GetCurrentStamina();

        _maxHealth = _mainCharacter.GetComponent<PlayerHealth>().GetMaxHealth();
        _maxStamina = _mainCharacter.GetComponent<CharacterStamina>().GetMaxStamina();

        _hpBar.value = _currentHealth / _maxHealth;
        _stBar.value = _currentStamina / _maxStamina;

        _hpText.text = _currentHealth.ToString() + " / " + _maxHealth.ToString();
        _stText.text = Mathf.Round(_currentStamina).ToString() + " / " + _maxStamina.ToString();
    }
}
