using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterHit : MonoBehaviour
{
    [SerializeField] float HitDelay = 1.1f;

    protected Movement Movement;
    protected bool IsCanHit = true;
    protected AnimationController AnimationControlller;

    #region INITIALIZE
    public void Initialize()
    {
        AnimationControlller = GetComponent<AnimationController>();
        Movement = GetComponent<Movement>();
    }
    #endregion

    public virtual void Hit()
    {
        if (IsCanHit)
        {
            StartCoroutine(Movement.Slowdown(0.7f, 1));
            GetComponent<AnimationController>().CombatUbtadeAnimation();
            StartCoroutine(HitDelayer());
        }
    }

    protected IEnumerator HitDelayer()
    {
        IsCanHit = false;
        yield return new WaitForSeconds(HitDelay);
        IsCanHit = true;
    }
}
