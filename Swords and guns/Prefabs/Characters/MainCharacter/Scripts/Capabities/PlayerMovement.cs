using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    private CharacterStamina _characterStamina;

    #region INITIALIZE
    public override void Initialize()
    {
        _characterStamina = GetComponent<CharacterStamina>();

        CharacterStats = GetComponent<CharacterStats>();
        Speed = CharacterStats.GetSpeed();
        JumpingPower = CharacterStats.GetJumpingPower();

        AnimationControlller = GetComponent<AnimationController>();
        RB = GetComponent<Rigidbody2D>();
        Shooting = GetComponent<Shooting>();
    }
    #endregion

    private void Update()
    {
        DirX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
            GetComponent<CharacterStamina>().TakeStamina(10);
        }

        AnimationControlller.MovementUpdateAnimation(DirX, IsGrounded());

        Flip(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void FixedUpdate()
    {
        RB.velocity = new Vector2(DirX * Speed, RB.velocity.y);

        if(DirX == 0) Standing();
        else if(_characterStamina.IsTired) Walking();
        else Running();
    }
}
