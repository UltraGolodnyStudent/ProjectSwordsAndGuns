using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    private void Start()
    {
        // string name, int damage, int maxAmmo, int currentAmmo, int bulletSpeed, int chargeOfBullets

        SetInfo("Rifle", 2, 10, 10, 30, 1);
    }
}
