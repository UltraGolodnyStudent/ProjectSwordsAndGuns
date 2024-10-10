using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BaseCharacterStats
{
    public const float 
        BaseMeleeDamage = 1, 
        BaseHP = 20, 
        BaseStamina = 200, 
        BaseSpeed = 10f, 
        BaseJumpingPower = 22f;

    public const int MinimalStat = 1;

    public const int 
        ArmStrength = MinimalStat, // id 0
        LegStrength = MinimalStat, // id 1
        CoreStrength = MinimalStat, // id 2

        ArmEndurance = MinimalStat, // id 3 
        LegEndurance = MinimalStat, // id 4 
        GeneralEndurance = MinimalStat; // id 5

    public static readonly List<int> stats = new List<int>() { ArmStrength, LegStrength, CoreStrength, ArmEndurance, LegEndurance, GeneralEndurance };
}
