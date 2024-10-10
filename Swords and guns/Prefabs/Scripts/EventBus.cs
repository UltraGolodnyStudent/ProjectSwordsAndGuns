using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventBus
{
    public static event Action <GameObject, GameObject> EnemyDied;
    public static event Action <GameObject, GameObject, float> AnyDamage;

    public static void ApplyDamage(GameObject damagedObject, GameObject damageCauser, float damage)
    {
        AnyDamage?.Invoke(damagedObject, damageCauser, damage);
    }
    public static void OnEnemyDied(GameObject diedObject, GameObject diedCauser)
    {
        EnemyDied?.Invoke(diedObject, diedCauser);
    }
}
