using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class OrbitWeapon : WeaponController
{
    private GameObject activeProjectile;
    public float orbitRadius = 5f; 
    private float angle = 0f; 
    
    public int numberOfProjectiles = 1; // Default is 1, you can adjust in the inspector
    private List<GameObject> activeProjectiles = new List<GameObject>();


    public override bool RequiresTargeting()
    {
        return false;
    }

    private void Update()
    {
        if (activeProjectiles.Count > 0)
        {
            float angleIncrement = 2 * Mathf.PI / numberOfProjectiles;
            for (int i = 0; i < activeProjectiles.Count; i++)
            {
                GameObject projectile = activeProjectiles[i];
                if (projectile)
                {
                    float currentAngle = angle + i * angleIncrement;
                    Vector3 offset = new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle), 0) * orbitRadius;
                    projectile.transform.position = playerTransform.position + offset;
                }
            }

            angle += Speed * Time.deltaTime;
            if (angle > 2 * Mathf.PI)
            {
                angle -= 2 * Mathf.PI;
            }
        }
    }


    public override void FireProjectile(Vector2 direction)
    {
        // Clear existing projectiles
        foreach (var proj in activeProjectiles)
        {
            if (proj) Destroy(proj);
        }
        activeProjectiles.Clear();

        float angleIncrement = 2 * Mathf.PI / numberOfProjectiles;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Vector3 spawnPosition = playerTransform.position + new Vector3(Mathf.Cos(i * angleIncrement) * orbitRadius, Mathf.Sin(i * angleIncrement) * orbitRadius, 0);
            GameObject newProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            
            activeProjectiles.Add(newProjectile);

            Projectile projectileScript = newProjectile.GetComponent<Projectile>();
            if (projectileScript)
            {
                projectileScript.isOrbiting = true;
                projectileScript.SetDuration(Duration);
                projectileScript.SetArea(Area);
                projectileScript.SetDamage(BaseDamage);
            }
            else
            {
                Debug.LogError("Projectile Script component is missing in the instantiated projectile.");
            }
        }
        // Start the life cycle of the projectile
        StartCoroutine(OrbitLifeCycle());
        Debug.Log("Starting orbital lifecycle for " + numberOfProjectiles + " projectiles.");
    }


    private IEnumerator OrbitLifeCycle()
    {
        yield return new WaitForSeconds(Duration); 

        // Destroy all active projectiles
        foreach (var proj in activeProjectiles)
        {
            if (proj) Destroy(proj);
        }
        activeProjectiles.Clear();

        yield return new WaitForSeconds(1f / AttackRate);

        Debug.Log("Ended attack cycle. Waiting for the next.");
        FireProjectile(Vector2.zero);
    }

}
