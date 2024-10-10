using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponPositions : MonoBehaviour
{
    [SerializeField] private GameObject _gunPosition;
    [SerializeField] private GameObject _meleeWeaponPosition;

    public GameObject GetGunPosition()
    {
        return _gunPosition;
    }
    public GameObject GetMeleeWeaponPosition()
    {
        return _meleeWeaponPosition;
    }
}
