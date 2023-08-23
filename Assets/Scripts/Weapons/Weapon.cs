using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string WeaponName;
    public int MaxLevel;
    public int Rarity;
    public int currentRank = 1;
    public List<WeaponRank> Ranks;

    [System.Serializable]
    public class WeaponRank
    {
        public string rankName;
        public float BaseDamage;
        public float Area;
        public float Speed;
        public float Duration;
        public bool UsePierce;
        public int Pierce;
        public float AttackRate;
        public bool UseHitboxDelay;
        public float HitboxDelay;
        public bool UseKnockback;
        public float Knockback;
        public bool UsePoolLimit;
        public int PoolLimit;
        public bool UseCritMulti;
        public float CritMulti;
        public bool BlockByWalls;
        public bool IgnorePlayerStats;
    }

    public WeaponRank GetCurrentRank(int currentRank)
    {
        if (currentRank < 0 || currentRank >= Ranks.Count)
        {
            // Handle the error - perhaps throw an exception with a clear message
            throw new ArgumentOutOfRangeException("currentLevel", "Current level must be non-negative and less than the number of Ranks.");
        }
        
        return Ranks[currentRank];
    }


    public void UpgradeToNewRank()
    {
        if (currentRank < Ranks.Count - 1) 
        {
            currentRank++;
        }
        else 
        {
            // Handle the error - perhaps log a warning that the maximum rank is already reached
            Debug.LogWarning("Maximum rank reached for this weapon.");
        }
    }


    public void ResetToBase()
    {
        currentRank = 1;
    }
}
