using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    #region PUBLIC
    public void MovementUpdateAnimation(float dirX, bool isGrounded)
    {
        if (dirX < 0) Run();
        else if (dirX == 0) Idle();
        else Run();

        if (!isGrounded) Jump();
        else Landing();
    }
    public void BMMovementUpdateAnimation(float dirX, bool isGrounded)
    {
        if (dirX < 0) Run();
        else if (dirX == 0) Idle();
        else Run();

        if (!isGrounded) Jump();
        else Landing();
    }
    public void CombatUbtadeAnimation()
    {
        Hitting();
    }

    public void UsingMeleeWeapon() => _animator.SetBool("useMeleeWeapon", true);
    public void UnUsingMeleeWeapon() => _animator.SetBool("useMeleeWeapon", false);

    public void UsingGun() => _animator.SetBool("useGun", true);
    public void UnUsingGun() => _animator.SetBool("useGun", false);
    public bool IsHitting()
    {
        var animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName("hit1") || animatorStateInfo.IsName("SwordHit"))
            return true;
        else
            return false;
    }
    #endregion

    #region PRIVATE
    // combat
    private void Hitting()
    {
        if (!IsHitting())
            _animator.SetTrigger("attack");
    }

    // movement 
    private void Idle() => _animator.SetBool("running", false);
    private void Run() => _animator.SetBool("running", true);
    private void Jump() => _animator.SetBool("jumping", true);
    private void Landing() => _animator.SetBool("jumping", false);
    #endregion
}
