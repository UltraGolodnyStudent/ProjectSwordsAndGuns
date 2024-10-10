using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponTaking : MonoBehaviour
{
    protected GameObject Object;
    protected Weapon Weapon;
    protected Shooting Shooting;
    protected AnimationController AnimationControlller;

    protected Transform GunPosition, MeleeWeaponPosition;

    protected bool Armed = false;

    #region INITIALIZE
    public void Initialize()
    {
        Shooting = GetComponent<Shooting>();
        AnimationControlller = GetComponent<AnimationController>();

        GunPosition = GetComponent<CharacterWeaponPositions>().GetGunPosition().transform;
        MeleeWeaponPosition = GetComponent<CharacterWeaponPositions>().GetMeleeWeaponPosition().transform;
    }
    #endregion

    #region PUBLIC
    public void WeaponThrow()
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

    public bool IsArmed() => Armed;

    protected void PickedUpWeapon()
    {
        Weapon = Object.GetComponent<Weapon>();

        if (Object.GetComponentInChildren<Gun>() != null)
        {
            Armed = true;
            Shooting.SetGun(Object);
            Weapon.WeaponTaking(GunPosition);
            Shooting.RotateGun();
            Shooting.RotateGunPosition();
            AnimationControlller.UsingGun();
        }
        else if(Object.GetComponentInChildren<MeleeWeapon>() != null)
        {
            Armed = true;
            Weapon.WeaponTaking(MeleeWeaponPosition);
            AnimationControlller.UsingMeleeWeapon();
        }
    }
    #endregion
}
