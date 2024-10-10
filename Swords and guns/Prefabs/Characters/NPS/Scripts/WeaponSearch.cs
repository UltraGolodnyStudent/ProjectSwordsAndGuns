using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSearch : MonoBehaviour
{
    private readonly List<GameObject> _weaponList = new();

    #region MONO
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_weaponList.Contains(collision.gameObject) == false) // иначе если у оружия несколько коллизий, его может несколько раз добавить в список
        {
            if (IsLoadedGun(collision))
            {
                _weaponList.Add(collision.gameObject);
                Debug.Log("WeaponSearch: ружье было добавлено в список " + collision.gameObject.name + " " + _weaponList.Contains(collision.gameObject));
            }

            else if (IsMeleeWeapon(collision))
            {
                _weaponList.Add(collision.gameObject);
                Debug.Log("WeaponSearch: меч был добавлен в список " + collision.gameObject.name);
            }
        }
        else Debug.Log(_weaponList.Contains(collision.gameObject));
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (_weaponList.Contains(collision.gameObject))
        {
            _weaponList.Remove(collision.gameObject);
            Debug.Log("WeaponSearch: было удалено из списка " + collision.gameObject.name);
        }
    }
    #endregion

    public bool ItContainsWeapons(Collider2D collision)
    {
        if (_weaponList.Contains(collision.gameObject))
            return true;
        return false;
    }

    public GameObject FindingWeapon()
    {
        GameObject targetWeapon = null;

        if (_weaponList.Count > 0)
        {
            float minDistance = 0;
            bool start = true;

            foreach (GameObject weapon in _weaponList)
            {
                float distance = Vector3.Distance(weapon.transform.position, transform.position);

                if (start)
                {
                    minDistance = distance;
                    start = false;
                    targetWeapon = weapon;
                }

                if (distance < minDistance)
                {
                    minDistance = distance;
                    targetWeapon = weapon;
                }
                Debug.Log("WeaponSearch: target weapon is " + targetWeapon);
            }
        }
        return targetWeapon;
    }

    public void RemoveFromWL(GameObject weapon) => _weaponList.Remove(weapon);


    private bool IsLoadedGun(Collision2D collision)
    {
        Gun gun = collision.gameObject.GetComponent<Gun>();
        if (gun != null && gun.IsEnoughAmmo())
            return true;
        return false;
    }
    private bool IsMeleeWeapon(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MeleeWeapon>() != null)
            return true;
        return false;
    }
}
