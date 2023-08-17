using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float projectileSize = 1f;
    public float projectileRange = 5f;
    public float spawnDistance = 1f;

    public void FireProjectile(Vector2 direction)
    {
        Debug.Log("Attempting to fire projectile.");
        // Calculate the spawn position
        Vector3 spawnPosition = transform.position + (Vector3)(direction.normalized * spawnDistance);

        GameObject proj = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        proj.GetComponent<Projectile>().shooterTag = gameObject.tag;  // This line ensures that the projectile knows who shot it.
        Debug.Log("Projectile created at " + proj.transform.position);
        proj.transform.localScale = new Vector3(projectileSize, projectileSize, 1);  // Set the size.

        Rigidbody2D projRB = proj.GetComponent<Rigidbody2D>();
        projRB.velocity = direction.normalized * projectileSpeed;

        // Destroy the projectile after it has traveled its range.
        Destroy(proj, projectileRange / projectileSpeed);
    }

    public LayerMask enemyLayers;
}
