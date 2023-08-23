using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Passive Item", menuName = "Passive Item")]
public class PassiveItem : ScriptableObject
{
    public string itemName;
    public int MaxLevel = 10;
    public int Rarity = 100;
    public int currentRank = 1;

    public List<EffectRank> effects = new List<EffectRank>();

    [System.Serializable]
    public class EffectRank
    {
        public string rankName = "Rank 1";
        public Effect effect;
    }

    [System.Serializable]
    public class Effect
    {
        public float DamageMod = 0f;
        public int Armor = 0;
        public float MaxHealthMod = 0f;
        public float Recovery = 0f;
        public float AttackRate = 0f;
        public float Area = 0f;
        public float Speed = 0f;
        public float Duration = 0f;
        public float MoveSpeed = 0f;
        public int Magnet = 0;
        public float Luck = 0f;
        public float Growth = 0f;
        public float Money = 0f;
        public int Revival = 0;
    }

    public void AddNewRank()
    {
        EffectRank newRank = new EffectRank();
        newRank.rankName = "Rank " + (effects.Count + 1).ToString();
        newRank.effect = new Effect();
        effects.Add(newRank);
    }

    public void UpgradeToNewRank(PlayerStats playerStats)
    {
        // This method is called to 'level up' this passive item
        // When this happens, the new effects are applied to the player
        if (currentRank < MaxLevel)
        {
            currentRank++;
            ApplyEffect(playerStats);
        }
    }

    public void ApplyEffect(PlayerStats playerStats)
    {
        // This method is called to apply this passive item's effects to the given player
        // It uses the player's ApplyX methods to update the player's stats
        if (currentRank >= 1 && currentRank <= effects.Count)
        {
            Effect effectToApply = effects[currentRank - 1].effect;

            // Apply effects using the PlayerStats' ApplyX methods
            playerStats.ApplyDamageMod(effectToApply.DamageMod);
            playerStats.ApplyArmor(effectToApply.Armor);
            playerStats.ApplyMaxHealthMod(effectToApply.MaxHealthMod);
            playerStats.ApplyRecovery(effectToApply.Recovery);
            playerStats.ApplyAttackRate(effectToApply.AttackRate);
            playerStats.ApplyArea(effectToApply.Area);
            playerStats.ApplySpeed(effectToApply.Speed);
            playerStats.ApplyDuration(effectToApply.Duration);
            playerStats.ApplyMoveSpeed(effectToApply.MoveSpeed);
            playerStats.ApplyMagnet(effectToApply.Magnet);
            playerStats.ApplyLuck(effectToApply.Luck);
            playerStats.ApplyGrowth(effectToApply.Growth);
            playerStats.ApplyMoney(effectToApply.Money);
            playerStats.ApplyRevival(effectToApply.Revival);
        }
        else
        {
            Debug.LogError("Invalid rank for passive item: " + currentRank);
        }
    }

    public Effect GetCurrentEffect(int currentRank)
    {
        return effects[Mathf.Clamp(currentRank - 1, 0, MaxLevel - 1)].effect;
    }

    public void ResetToBase()
    {
        // Reset this passive item back to its initial rank
        // This might be called when the player moves to a new level or after player death, 
        // or when you want to remove this item's effects from the player
        currentRank = 1;

        // Get the base rank stats (i.e., the stats for Rank 1)
        Effect baseEffectStats = effects[0].effect;
    }
}
