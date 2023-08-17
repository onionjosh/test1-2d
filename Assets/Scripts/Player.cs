using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public PlayerStats playerStats;
    public Weapon equippedWeapon;

    private void Start()
    {
        // Example: Player equips a weapon
        equippedWeapon.ModifyStatsBasedOnPlayer(playerStats);
    }

    private void Attack()
    {
        // Example: Player attacks an enemy
        float damage = equippedWeapon.CalculateActualDamage();

        // ... apply this 'damage' to the enemy
    }
}

