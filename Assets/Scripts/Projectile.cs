using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]  // Ensure there's a Rigidbody2D component on the object
public class Projectile : MonoBehaviour
{
    public string shooterTag;

    private HealthSystem cachedHealthSystem;  // Cache references to components we'll be interacting with often
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.isKinematic = true;  // If your projectile doesn't need physics-based movement, set it to kinematic
    }

    private void OnTriggerEnter2D(Collider2D collider)  // Using triggers instead of collisions
    {
        // If the collided object's tag matches the shooterTag, then return immediately.
        if (collider.gameObject.CompareTag(shooterTag) || collider.gameObject.CompareTag("Gem"))
        {
            return;
        }

        // Cache the HealthSystem component if not already cached or if interacting with a different object
        if (!cachedHealthSystem || cachedHealthSystem.gameObject != collider.gameObject)
        {
            cachedHealthSystem = collider.GetComponent<HealthSystem>();
        }

        if (cachedHealthSystem != null)
        {
            cachedHealthSystem.TakeDamage(damage);
            Destroy(gameObject);  // Destroy the projectile after it hits an enemy
            return;  // Return here so the projectile doesn't also get destroyed by walls (if you want that behavior)
        }

        // If the projectile hits a wall or similar obstacle, destroy it.
        if (collider.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

}

