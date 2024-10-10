using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private const float 
        BaseMeleeDamage = BaseCharacterStats.BaseMeleeDamage,
        BaseHP = BaseCharacterStats.BaseHP,
        BaseStamina = BaseCharacterStats.BaseStamina,
        BaseSpeed = BaseCharacterStats.BaseSpeed,
        BaseJumpingPower = BaseCharacterStats.BaseJumpingPower,

        ArmStrengthHPFactor = StatMultiplier.ArmStrengthHPFactor,
        LegStrengthHPFactor = StatMultiplier.LegStrengthHPFactor,
        CoreStrengthHPFactor = StatMultiplier.CoreStrengthHPFactor,

        ArmStrengthDamageFactor = StatMultiplier.ArmStrengthDamageFactor,

        LegStrengthSpeedFactor = StatMultiplier.LegStrengthSpeedFactor,

        LegStrengthJumpFactor = StatMultiplier.LegStrengthJumpFactor,

        GeneralEnduranceFactor = StatMultiplier.GeneralEnduranceFactor;

    /* 
    ArmStrength id 0
    LegStrength id 1
    CoreStrength id 2

    ArmEndurance id 3
    LegEndurance id 4
    GeneralEndurance id 5 
    */
    private readonly List<int> stats = BaseCharacterStats.stats;

    #region PUBLIC
    public float GetMeleeDamage()
    {
        return BaseMeleeDamage + stats[0] * ArmStrengthDamageFactor;
    }
    public float GetMaxHP()
    {
        return BaseHP +
            stats[0] * ArmStrengthHPFactor +
            stats[1] * LegStrengthHPFactor +
            stats[2] * CoreStrengthHPFactor;
    }
    public float GetMaxStamina()
    {
        return BaseStamina + stats[5] * GeneralEnduranceFactor;
    }
    public float GetSpeed()
    {
        return BaseSpeed + stats[1] * LegStrengthSpeedFactor;
    }
    public float GetJumpingPower()
    {
        return BaseJumpingPower + stats[1] * LegStrengthJumpFactor;
    }

    public void AddStat(int statID, int addedPoints)
    {
        stats[statID] += addedPoints;
    }
    public void TakeStat(int statID, int addedPoints)
    {
        if (stats[statID] > addedPoints)
            stats[statID] -= addedPoints;
        else stats[statID] = 1;
    }
    #endregion
}
