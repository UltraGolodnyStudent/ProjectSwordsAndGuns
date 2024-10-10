using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool IsRunning { get; protected set; } = true;
    public bool IsWalking { get; protected set; } = false;
    public bool IsStanding { get; protected set; } = false;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    protected float DirX;
    protected float Speed;
    protected float JumpingPower;
    protected AnimationController AnimationControlller;
    protected Rigidbody2D RB;
    protected Shooting Shooting;
    protected CharacterStats CharacterStats;

    private readonly float _tiredFactor = 3;

    #region INITIALIZE
    public virtual void Initialize()
    {
        CharacterStats = GetComponent<CharacterStats>();
        Speed = CharacterStats.GetSpeed();
        JumpingPower = CharacterStats.GetJumpingPower();
    }
    #endregion

    #region PUBLIC
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }
    public void UpdateSpeed()
    {
        if(IsRunning)
            Speed = CharacterStats.GetSpeed();
        else
            Speed = CharacterStats.GetSpeed()/_tiredFactor;

        JumpingPower = CharacterStats.GetJumpingPower();
    }
    #endregion

    #region PROTECTED
    protected void Jump()
    {
        RB.velocity = new Vector2(RB.velocity.x, JumpingPower);
    }
    protected void Running()
    {
        if (!IsRunning)
        {
            IsRunning = true;
            IsWalking = false;
            IsStanding = false;
            UpdateSpeed();
        }
    }
    protected void Walking()
    {
        if (!IsWalking)
        {
            IsRunning = false;
            IsWalking = true;
            IsStanding = false;
            Speed /= 3;
            JumpingPower = 0;
        }
    }
    protected void Standing()
    {
        if (!IsStanding)
        {
            IsRunning = false;
            IsWalking = false;
            IsStanding = true;
        }
    }

    protected void Flip(Vector3 target)
    {
        if (GetComponentInChildren<WeaponTaking>().IsArmed())
        {
            ArmedFlip(target);
        }
        else
        {
            MovementFlip();
        }
    }

    protected void Flip()
    {
        MovementFlip();
    }
    #endregion


    #region PRIVATE
    private void MovementFlip()
    {
        if (transform.localScale.x == 1 && DirX < 0f || transform.localScale.x == -1 && DirX > 0f)
        {
            Turn();
        }
    }

    private void ArmedFlip(Vector3 target)
    {
        Vector3 difference = target - transform.position;
        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (rotation_z > 90 && transform.localScale.x == 1) TurnWithWeapon();
        else if (rotation_z < -90 && transform.localScale.x == 1) TurnWithWeapon();
        else if(rotation_z < 90 && rotation_z > 0 && transform.localScale.x == -1) TurnWithWeapon();
        else if(rotation_z > -90 && rotation_z < 0 && transform.localScale.x == -1) TurnWithWeapon();
    }

    private void Turn()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void TurnWithWeapon()
    {
        Turn();
        Shooting.RotateGunPosition();
        Shooting.RotateGun();
    }
    #endregion

    public IEnumerator Slowdown(float SlowdownFactor, float SlowdownTime)
    {
        float startSpeed = Speed;
        Speed -= Speed * SlowdownFactor;

        yield return new WaitForSeconds(SlowdownTime);

        Speed = startSpeed;
    }
}
