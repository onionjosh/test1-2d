using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance { get; private set; }
    public GameObject projectilePrefab;
    public int poolSize = 10;
    private List<GameObject> pooledProjectiles;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pooledProjectiles = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            pooledProjectiles.Add(obj);
        }
    }

    public GameObject GetPooledProjectile()
    {

        Debug.Log("GetPooledProjectile called");
        foreach (GameObject obj in pooledProjectiles)
        {
            if (!obj.activeInHierarchy)
            {
                Debug.Log("Projectile Activated");
                return obj;
            }
        }

        // If no inactive projectiles are available, create a new one and add it to the pool
        GameObject newObj = Instantiate(projectilePrefab);
        newObj.SetActive(false);
        pooledProjectiles.Add(newObj);
        return newObj;
    }
}
