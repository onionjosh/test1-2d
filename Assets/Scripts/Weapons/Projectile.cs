using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string Player;
    public float velocity;
    public float duration;
    public float area;
    public float damage;
    public string enemyTag = "Enemy";
    public bool isOrbiting = false;


    private Rigidbody2D rb2D;

    private float creationTime;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    public void SetDuration(float duration)
    {
        Destroy(gameObject, duration);
        creationTime = Time.time;
    }

    public void SetDamage(float damageValue)
    {
        damage = damageValue;
    }

    public void SetArea(float areaValue)
    {
        area = areaValue;
        AdjustSize();
    }

    public void SetVelocity(Vector2 velocity)
    {
        if (rb2D == null) 
        {
            Debug.LogError("Rigidbody2D component missing from this gameobject");
            return;
        }
        rb2D.velocity = velocity;
        //Debug.Log("Projectile Velocity: " + velocity);
    }

    private void AdjustSize()
    {
        float scaleFactor = Mathf.Sqrt(area); // Convert area to a scale factor
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Projectile collided with: " + collider.gameObject.name);

        if (collider.gameObject.CompareTag(Player))
        {
            return;
        }

        HealthSystem cachedHealthSystem = collider.GetComponent<HealthSystem>();

        if (cachedHealthSystem != null)
        {
            cachedHealthSystem.TakeDamage((int)damage);

            // If it's not an orbiting projectile, destroy it.
            if (!isOrbiting)
            {
                Destroy(gameObject);
            }
            
            return;
        }

        if (collider.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }


    private void OnDestroy()
    {
        float durationAlive = Time.time - creationTime;
        //Debug.Log("Projectile was destroyed. It lasted for: " + durationAlive + " seconds. Position: " + transform.position);
    }
}
