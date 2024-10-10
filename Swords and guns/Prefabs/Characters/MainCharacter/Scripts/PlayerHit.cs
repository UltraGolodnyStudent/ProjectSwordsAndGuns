using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : CharacterHit
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && Movement.IsGrounded())
        {
            if (!GetComponent<CharacterStamina>().IsTired)
                Hit();
        }
    }
    public override void Hit()
    {
        if (IsCanHit)
        {
            StartCoroutine(Movement.Slowdown(0.7f, 1));
            AnimationControlller.CombatUbtadeAnimation();
            GetComponent<CharacterStamina>().TakeStamina(40);
            StartCoroutine(HitDelayer());
        }
    }
}
