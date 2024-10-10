using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private GameObject _bulletType;
    [SerializeField] private Transform _spawnBulletPosition;

    private int _maxAmmo = 1;
    private int _currentAmmo = 1;

    private int _bulletSpeed = 10;
    private int _chargeOfBullets = 1; // сколько пуль выпускает за раз

    private float _shotDelay = 1;
    private float _reloadDelay = 2;

    private bool _isCanShot = true;
    private bool _isCanReload = true;

    protected void SetInfo(string name, int damage, int maxAmmo, int currentAmmo, int bulletSpeed, int chargeOfBullets)
    {
        Name = name;
        Damage = damage;
        _maxAmmo = maxAmmo;
        _currentAmmo = currentAmmo;
        _bulletSpeed = bulletSpeed;
        _chargeOfBullets = chargeOfBullets;

        WeaponType = "Gun";
    }


    public void GetInfo()
    {
        // дает информацию о огнестрельном оружии
    }

    public void Shot()
    {
        if (_isCanShot)
        {
            if (_currentAmmo - _chargeOfBullets >= 0)
            {
                GameObject bullet;

                bullet = Instantiate(_bulletType, _spawnBulletPosition.transform.position, transform.rotation);
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().ShotBullet(Damage, _bulletSpeed);

                _currentAmmo -= _chargeOfBullets;
                // добавить звуки и анимацию

                StartCoroutine(DelaysTheShot());
            }
            else
            {
                // добавить звуки и анимацию
            }
        }
    }

    public bool IsEnoughAmmo()
    {
        if (_currentAmmo - _chargeOfBullets >= 0) 
            return true;
        return false;
    }

    public void Reload()
    {
        // добавить звуки и анимацию
        if(_isCanReload)
            StartCoroutine(Reloading());
    }

    public void Taking(Transform gunPosition)
    {
        transform.SetPositionAndRotation(gunPosition.transform.position, gunPosition.transform.rotation);
        transform.parent = gunPosition.transform;
    }


    private IEnumerator Reloading()
    {
        _isCanReload = false;
        yield return new WaitForSeconds(_reloadDelay);
        _currentAmmo = _maxAmmo;
        _isCanReload = true;
    }

    private IEnumerator DelaysTheShot()
    {
        _isCanShot = false;
        yield return new WaitForSeconds(_shotDelay);
        _isCanShot = true;
    }
}
