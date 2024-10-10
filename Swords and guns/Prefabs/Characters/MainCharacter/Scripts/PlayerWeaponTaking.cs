using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponTaking : WeaponTaking
{
    private int _multipleTriggerActive = 0; // рядом может лежать несколько элементов оружия и их коллизии могут накладываться друг на друга

    #region MONO
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Object != null) 
            PickedUpWeapon();

        if (Input.GetKeyDown(KeyCode.Z) && Weapon != null)
            WeaponThrow();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon") // находим оружие
        {
            Object = collision.gameObject;
            _multipleTriggerActive++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Weapon" && _multipleTriggerActive == 1)
        {
            Object = null;
            _multipleTriggerActive--;
        }
        if (collision.tag == "Weapon" && _multipleTriggerActive > 1) // мы не освобождаем поле т. к. оно уже занято другим обьектом
            _multipleTriggerActive--;
    }
    #endregion
}
