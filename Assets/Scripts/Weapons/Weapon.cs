using UnityEngine;
using System.Collections.Generic;

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


    public void ModifyStatsBasedOnPlayer(PlayerStats playerStats)
    {
        WeaponRank rank = GetCurrentRank(currentRank);

        rank.BaseDamage *= (1 + playerStats.DamageMod / 100f);
        rank.Area *= (1 + playerStats.Area / 100f);
        rank.Speed *= (1 + playerStats.Speed / 100f);
        rank.Duration *= (1 + playerStats.Duration / 100f);
        rank.AttackRate *= (1 + playerStats.AttackRate / 100f);
        // ... you can continue this pattern for any other stats

       // Assuming some custom logic for certain stats:
       // rank.Pierce = (int)(rank.Pierce * (1 + playerStats.Luck / 100f));
       // rank.CritMulti *= (1 + playerStats.Growth / 100f);
       // rank.Knockback *= (1 + playerStats.MoveSpeed / 100f);
    }



    // Calculates the actual damage this weapon will deal
    public float CalculateActualDamage()
    {
        WeaponRank rank = GetCurrentRank(currentRank);
        // Here you can introduce more factors, e.g., enemy defense
        return rank.BaseDamage;
    }


    public WeaponRank GetCurrentRank(int currentLevel)
    {
        return Ranks[Mathf.Clamp(currentLevel - 1, 0, MaxLevel - 1)];
    }


    // Function to upgrade the weapon to a new rank
    public void UpgradeToNewRank(PlayerStats playerStats)
    {
        if (currentRank < MaxLevel)
        {
            currentRank++;

            // Update the weapon's stats to match the new rank's stats
            WeaponRank newRankStats = GetCurrentRank(currentRank);

            // Optionally, trigger some effects to indicate the weapon has been upgraded

            // Reapply the player’s stat modifiers to these new base stats
            ModifyStatsBasedOnPlayer(playerStats);
        }
        else
        {
            Debug.Log("Weapon is already at max level!");
        }
    }

    public void ResetToBase()
    {
        // Reset the current rank to 1
        currentRank = 1;

        // Reset the weapon's stats to match the Rank 1 stats
        WeaponRank baseRankStats = GetCurrentRank(currentRank);

        // Here, you might need to set the stats of the weapon back to the base values
        // For example:
       // baseRankStats.BaseDamage = Ranks[0].BaseDamage;
      //  baseRankStats.Area = Ranks[0].Area;
        // ... and so on for other stats
    }


}
