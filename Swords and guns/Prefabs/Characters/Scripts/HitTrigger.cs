using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    private CharacterStats _stats;

    public void Initialize()
    {
        _stats = GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponentInChildren<CharacterHealth>() != null)
            EventBus.ApplyDamage(collision.gameObject, gameObject, _stats.GetMeleeDamage());

        //GetComponent<Damage>().ApplyDamage(collision.gameObject, gameObject, _stats.GetMeleeDamage());

        //if (collision.tag == "Player" && collision.GetComponentInChildren<CharacterHealth>() != null)
        //{
        //    Debug.Log("Попадание"); // звук и эффекты
        //    collision.GetComponentInChildren<CharacterHealth>().Damage(_stats.GetMeleeDamage());
        //}
    }
}
