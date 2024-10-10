using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleCombat : AICombat
{
    private AIHit _hitting;

    #region INITIALIZE
    public new void Initialize(GameObject mainCharacter)
    {
        Player = mainCharacter.transform;
        Movement = GetComponent<AIMovement>();
        _hitting = GetComponent<AIHit>();
    }
    #endregion

    private void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.position);

        if (Distance < AggroDistance)
        {
            CombatMode = true;

            Movement.MoveAtTarget(Player, Distance, CombatDistance);

            if(Movement.IsGrounded())
                Hitting();
        }
        else
        {
            CombatMode = false;
            Movement.StopMoving();
        }
    }

    private void Hitting()
    {
        if (Distance <= CombatDistance)
        {
            _hitting.Hit();
        }
    }
}
