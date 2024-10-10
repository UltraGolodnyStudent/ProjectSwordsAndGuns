using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private GameObject _gunPosition;
    private Gun _gun;
    private WeaponTaking _weaponTaking;

    #region INITIALIZE
    public void Initialize()
    {
        _gunPosition = GetComponent<CharacterWeaponPositions>().GetGunPosition();
        _weaponTaking = GetComponentInChildren<WeaponTaking>();
    }
    #endregion

    public void SetGun(GameObject gun) => _gun = gun.GetComponent<Gun>();

    public void GunShot() => _gun?.Shot();

    public void GunReload() => _gun?.Reload();

    public void GunTargetTracking(Transform target)
    {
        if(_weaponTaking.IsArmed())
            _gun?.WeaponTargetTracking(target.position); // потом к ружью можно будет прикрепить кости рук
    }
    public void GunCursorTracking()
    {
        if(_weaponTaking.IsArmed())
            _gun?.WeaponTargetTracking(Camera.main.ScreenToWorldPoint(Input.mousePosition)); // потом к ружью можно будет прикрепить кости рук
    }
    public bool IsEnoughAmmo(Gun gun)
    {
        try { return gun.IsEnoughAmmo(); }
        catch { throw new System.Exception("Gun is null."); }
    }
    public bool IsEnoughAmmo()
    {
        try { return _gun.IsEnoughAmmo();}
        catch { throw new System.Exception("Gun is null."); }
    }

    public void RotateGun()
    {
        float localScaleX = transform.localScale.x;
        _gun?.RotateWeapon(localScaleX);
    }
    public void RotateGunPosition()
    {
        try
        {
            _gunPosition?.GetComponent<WeaponPosition>().RotateWeaponPosition(transform.localScale);
        }
        catch { throw new System.Exception("Install the weapon position script to the object."); }
    }
}
