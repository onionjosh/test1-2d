using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager Instance { get; private set; }

    private Dictionary<string, ProjectilePool> projectilePools;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            projectilePools = new Dictionary<string, ProjectilePool>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public ProjectilePool GetPool(string projectileType)
    {
        if (!projectilePools.ContainsKey(projectileType))
        {
            // Create a new pool for this type of projectile
            GameObject poolObj = new GameObject(projectileType + "Pool");
            poolObj.transform.parent = this.transform;
            ProjectilePool pool = poolObj.AddComponent<ProjectilePool>();
            projectilePools[projectileType] = pool;
        }
        return projectilePools[projectileType];
    }
}
