using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeaponTaking : WeaponTaking
{
    WeaponSearch _weaponSearch;

    #region INITIALIZE
    public void Initialize(GameObject startWeapon, WeaponSearch weaponSearch)
    {
        Initialize();

        _weaponSearch = weaponSearch;

        if (startWeapon != null)
        {
            Object = Instantiate(startWeapon, transform.position, transform.rotation);
            PickedUpWeapon();
        }
    }
    #endregion

    #region MONO
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickedUpCollisionWeapon(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PickedUpCollisionWeapon(collision);
    }
    #endregion

    #region PUBLIC
    public GameObject FoundWeapon()
    {
        if (!Armed)
            return _weaponSearch?.FindingWeapon();
        return null;
    }
    public new void WeaponThrow()
    {
        if (Weapon != null)
        {
            Armed = false;
            Weapon.WeaponThrow();
            Weapon = null;
            AnimationControlller.UnUsingGun();
            AnimationControlller.UnUsingMeleeWeapon();
        }
    }
    #endregion

    private void PickedUpCollisionWeapon(Collider2D collision)
    {
        if (_weaponSearch != null && _weaponSearch.ItContainsWeapons(collision))
        {
            PickedUpWeapon();
            Debug.Log("AIWeaponTaking: оружие " + collision.gameObject.name + " подобрано");
        }
    }
}
