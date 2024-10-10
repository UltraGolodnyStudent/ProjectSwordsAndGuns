using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPosition : MonoBehaviour
{
    public void RotateWeaponPosition(Vector3 localScale)
    {
        transform.localScale = localScale;
    }
}
