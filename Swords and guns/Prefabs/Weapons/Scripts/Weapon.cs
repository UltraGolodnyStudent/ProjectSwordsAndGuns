using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected string Name = "weapon";
    protected string WeaponType = "indefinite";
    protected int Damage = 1;

    public void WeaponTaking(Transform weaponPosition)
    {
        foreach (BoxCollider2D collider in GetComponents<BoxCollider2D>())
        {
            collider.enabled = false;
        }

        GetComponent<Rigidbody2D>().simulated = false;

        Vector3 rotate = Vector3.zero;
        transform.rotation = Quaternion.Euler(rotate);

        transform.SetPositionAndRotation(weaponPosition.transform.position, weaponPosition.transform.rotation);
        transform.parent = weaponPosition.transform;
    }

    public void WeaponThrow()
    {
        transform.parent = null;

        foreach (BoxCollider2D collider in GetComponents<BoxCollider2D>())
        {
            collider.enabled = true;
        }

        GetComponent<Rigidbody2D>().simulated = true;
    }

    public void WeaponTargetTracking(Vector3 target)
    {
        TargetRotation.SetRotation(target, transform);
    }


    #region ROTATION
    public void SetBaseWeaponRotation()
    {
        Vector3 rotate = Vector3.zero;
        transform.rotation = Quaternion.Euler(rotate);
    }

    public void RotateWeapon(float localScaleX)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = 1;
        localScale.y = localScaleX;
        localScale.z = 1;
        transform.localScale = localScale;
    }
    #endregion
}
