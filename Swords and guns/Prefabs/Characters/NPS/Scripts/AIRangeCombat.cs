using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRangeCombat : AICombat
{
    private Shooting _shooting;
    private AIWeaponTaking _weaponTaking;
    private GameObject _foundWeapon;

    #region INITIALIZE
    public override void Initialize(GameObject mainCharacter)
    {
        Player = mainCharacter.transform;
        Movement = GetComponent<AIMovement>();
        _shooting = GetComponent<Shooting>();
        _weaponTaking = GetComponent<AIWeaponTaking>();
    }
    #endregion

    private void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.position);

        if (_weaponTaking.IsArmed() && _shooting.IsEnoughAmmo())
        {
            if (Distance < AggroDistance)
            {
                CombatMode = true;

                Movement.MoveAtTarget(Player, Distance, CombatDistance);

                Shooting();
            }
            else
            {
                CombatMode = false;
                Movement.StopMoving();
            }
        }
        else if (_weaponTaking.IsArmed() && !_shooting.IsEnoughAmmo())
        {
            ChangeWeapons();
        }
        else
        {
            if (_foundWeapon != null)
            {
                Movement.MoveAtTarget(_foundWeapon.transform);
            }
            else
            {
                GetComponent<AIMeleCombat>().enabled = true;
                enabled = false;
            }
        }
    }

    private void Shooting()
    {
        if (Distance <= CombatDistance)
        {
            _shooting.GunTargetTracking(Player);
            _shooting.GunShot();
        }
    }
    private void ChangeWeapons()
    {
        _weaponTaking.WeaponThrow();

        _foundWeapon = _weaponTaking.FoundWeapon();
    }
}
