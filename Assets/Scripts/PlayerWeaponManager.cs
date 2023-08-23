using UnityEngine;
using System.Collections.Generic;

public class PlayerWeaponManager : MonoBehaviour
{
    public List<WeaponController> equippedWeapons = new List<WeaponController>();

    public Transform weaponsParentTransform;
    public string enemyTag = "Enemy"; // Tag to identify enemies

    

    void Update()
    {
        // Find the nearest enemy
        GameObject nearestEnemy = FindNearestEnemy();

        // Calculate direction to the nearest enemy
        Vector2 targetDirection = nearestEnemy ? (nearestEnemy.transform.position - transform.position).normalized : Vector2.zero;

        // Attempt to fire each equipped weapon at the target direction
        foreach (var weapon in equippedWeapons)
        {
            if (weapon.RequiresTargeting() && nearestEnemy != null)
            {
                weapon.AttemptToFire(targetDirection);
            }
            else if (!weapon.RequiresTargeting())
            {
                weapon.AttemptToFire(Vector2.zero); // You can use zero or any default value. It won't matter because OrbitWeapon ignores it.
            }
        }
    }



    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    public void AddWeapon(Weapon weaponData, GameObject projectilePrefab)
    {
        GameObject newWeaponObject = new GameObject("Weapon");
        newWeaponObject.transform.SetParent(weaponsParentTransform);
        WeaponController newWeapon = newWeaponObject.AddComponent<WeaponController>();

        newWeapon.weaponData = weaponData;
        newWeapon.projectilePrefab = projectilePrefab;

        equippedWeapons.Add(newWeapon);
    }

    public void RemoveWeapon(WeaponController weapon)
    {
        equippedWeapons.Remove(weapon);
        Destroy(weapon.gameObject);
    }

   // public void RemoveWeapon(WeaponControllerFireball fireball)
    //{
    //    equippedWeapons.Remove(fireball);
    //    Destroy(weapon.gameObject);
    //}


    public void ClearWeapons()
    {
        foreach (var weapon in equippedWeapons)
        {
            Destroy(weapon.gameObject);
        }
        equippedWeapons.Clear();
    }
}
