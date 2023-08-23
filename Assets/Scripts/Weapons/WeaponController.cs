using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    public Weapon weaponData;
    public GameObject projectilePrefab;
    public Transform playerTransform;

    protected float BaseDamage;
    protected float Area;
    protected float Speed;
    protected float Duration;
    protected float AttackRate;

    private float nextFireTime;

    public virtual bool RequiresTargeting()
    {
        return true;
    }


    private void Start()
    {
        UpdateWeaponStats();

        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }


    public virtual void AttemptToFire(Vector2 direction)
    {
        if (Time.time > nextFireTime)
        {
            FireProjectile(direction);
            nextFireTime = Time.time + 1 / AttackRate;
        }
    }

    public virtual void UpdateWeaponStats()
    {
        var currentWeaponRank = weaponData.GetCurrentRank(weaponData.currentRank);
        
        var playerStats = PlayerStats.Instance; // Assume you have a PlayerStats singleton
        
        BaseDamage = currentWeaponRank.BaseDamage * (1 + playerStats.DamageMod / 100f);
        Area = currentWeaponRank.Area * (1 + playerStats.Area / 100f);
        Speed = currentWeaponRank.Speed * (1 + playerStats.Speed / 100f);
        Duration = currentWeaponRank.Duration * (1 + playerStats.Duration / 100f);
        AttackRate = currentWeaponRank.AttackRate * (1 + playerStats.AttackRate / 100f);
    }

    public virtual void FireProjectile(Vector2 direction)
    {
        Vector3 spawnPosition = playerTransform.position; // Use player's position
        spawnPosition.z = 0;


        GameObject projectileInstance = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        Projectile projectileScript = projectileInstance.GetComponent<Projectile>(); // This is the key line
     
        if (projectileScript == null)
            {
                Debug.LogError("Projectile Script component is missing in the instantiated projectile.");
                return;
            }

        if (projectileInstance != null)
            {

            projectileScript.SetVelocity(direction * Speed);
            projectileScript.SetDuration(Duration);
            projectileScript.SetArea(Area);
            projectileScript.SetDamage(BaseDamage);
            //Debug.Log("Final Base Damage: " + BaseDamage);
            }
        else
            {
            Debug.LogError("Projectile instantiation failed.");
            }

        if (projectileScript == null)
            {
            Debug.LogError("Projectile Script component is missing in the instantiated projectile.");
            return;
            }    
    }


}

