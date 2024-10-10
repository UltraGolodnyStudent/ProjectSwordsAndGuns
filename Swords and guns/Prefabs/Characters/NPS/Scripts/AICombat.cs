using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour
{
    [SerializeField] protected float AggroDistance = 25;
    [SerializeField] protected float CombatDistance = 10;

    protected Transform Player;
    protected AIMovement Movement;
    protected float Distance;
    protected bool CombatMode;

    #region INITIALIZE
    public virtual void Initialize(GameObject mainCharacter)
    {
        Player = mainCharacter.transform;
        Movement = GetComponent<AIMovement>();
    }
    #endregion

    private void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.position);

        if (Distance < AggroDistance)
        {
            CombatMode = true;

            Movement.MoveAtTarget(Player, Distance, CombatDistance);

            // какое-то действие
        }
        else
        {
            CombatMode = false;
            Movement.StopMoving();
        }
    }

    public bool GetCombatMode()
    {
        return CombatMode;
    }
}
