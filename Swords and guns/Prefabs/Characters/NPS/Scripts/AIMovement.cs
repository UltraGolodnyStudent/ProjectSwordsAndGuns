using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : Movement
{
    private Transform _playerTransform;
    private AIMeleCombat _aIMeleCombat;
    private AIRangeCombat _aIRangeCombat;

    #region INITIALIZE
    public void Initialize(GameObject mainCharacter)
    {
        CharacterStats = GetComponent<CharacterStats>();
        Speed = CharacterStats.GetSpeed();
        JumpingPower = CharacterStats.GetJumpingPower();

        AnimationControlller = GetComponent<AnimationController>();
        RB = GetComponent<Rigidbody2D>();
        Shooting = GetComponent<Shooting>();

        _playerTransform = mainCharacter.transform;
        _aIMeleCombat = GetComponent<AIMeleCombat>();
        _aIRangeCombat = GetComponent<AIRangeCombat>();
    }
    #endregion

    #region MONO
    private void Update()
    {
        AnimationControlller.MovementUpdateAnimation(DirX, IsGrounded());

        if (!_aIMeleCombat.GetCombatMode())
            Flip(_playerTransform.position);

        else if (_aIRangeCombat == null)
            Flip(_playerTransform.position);

        else if (_aIRangeCombat.enabled == false)
            Flip(_playerTransform.position);
    }

    private void FixedUpdate()
    {
        RB.velocity = new Vector2(DirX * Speed, RB.velocity.y);
    }
    #endregion

    public void MoveAtTarget(Transform target, float currentDistance, float finalDistance)
    {
        if (currentDistance > finalDistance)
        {
            if (transform.position.x - target.position.x > 0)
                DirX = -1;
            else DirX = 1;
        }
        else DirX = 0;
    }

    public void MoveAtTarget(Transform target)
    {
        if (transform.position.x - target.position.x > 0)
            DirX = -1;
        else DirX = 1;
    }

    public void StopMoving()
    {
        DirX = 0;
    }
}
