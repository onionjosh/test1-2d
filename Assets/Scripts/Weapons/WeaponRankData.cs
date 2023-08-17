using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Rank Data")]
public class WeaponRankData : ScriptableObject
{
    public RankUpgrade[] rankUpgrades;

    [System.Serializable]
    public class RankUpgrade
    {
        public int rank;
        public float damageBoost;             // Corresponds to BaseDamage
        public float areaBoost;               // Corresponds to Area
        public float speedBoost;              // Corresponds to Speed
        public int amountBoost;               // Corresponds to Amount
        public float durationBoost;           // Corresponds to Duration
        public float cooldownBoost;           // Corresponds to Cooldown
        public int pierceBoost;               // Corresponds to Pierce
        public float knockbackBoost;          // Corresponds to Knockback
        public float projectileIntervalBoost; // Corresponds to ProjectileInterval
        public float hitboxDelayBoost;        // Corresponds to HitboxDelay
        public int poolLimitBoost;            // Corresponds to PoolLimit
        public float critMultiBoost;          // Corresponds to CritMulti
        // If there are more stat lines, they would be added here following the same pattern.
    }
}
