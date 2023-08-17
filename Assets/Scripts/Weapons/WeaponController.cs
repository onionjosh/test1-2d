using UnityEngine;

public class WeaponController
{
    private Transform firePoint;
    private Weapon weaponData;
    private GameObject projectilePrefab;
    private float nextFireTime = 0f;

    public WeaponController(Transform _firePoint, Weapon _weaponData, GameObject _projectilePrefab)
    {
        firePoint = _firePoint;
        weaponData = _weaponData;
        projectilePrefab = _projectilePrefab;
    }

    public void UpdateWeapon()
    {
        if (Time.time > nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + 1 / weaponData.GetCurrentRank(weaponData.currentRank).AttackRate;
        }
    }

    private void FireProjectile()
    {
        GameObject projectileInstance = GameObject.Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
        projectileScript.speed = weaponData.GetCurrentRank(weaponData.currentRank).Speed;
        // You can set other properties of the Projectile here based on the weaponData
    }
}
