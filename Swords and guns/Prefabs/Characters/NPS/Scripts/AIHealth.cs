using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : CharacterHealth
{
    private float _delayOfDeath = 1;

    override protected void Death(GameObject diedObject, GameObject diedCauser)
    {
        if (diedObject == gameObject)
        {
            Debug.Log("ИИ " + diedObject + " был убит " + diedCauser);

            // отключить все коллизии и скрипты кроме этого

            diedCauser.GetComponent<Scaling>().AddExperience(300);

            GetComponent<AIWeaponTaking>().WeaponThrow();
            GetComponent<CapsuleCollider2D>().enabled = false;

            StartCoroutine(DelaysTheDeath());
        }
    }

    private IEnumerator DelaysTheDeath()
    {
        yield return new WaitForSeconds(_delayOfDeath);
        Destroy(gameObject);
    }
}
