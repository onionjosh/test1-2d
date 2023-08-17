using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;

    [Tooltip("Distance within which the enemy can attack the player.")]
    public float attackRange = 0.5f;

    [Tooltip("Time in seconds between consecutive attacks.")]
    public float attackCooldown = 1f;

    public int damage = 10;

    [Header("Gem Drop System")]
    public GameObject[] gemPrefabs;  // An array to hold all gem prefabs. Assign in the inspector.
    [Range(0, 1)] public float dropRate = 0.5f;  // Probability of dropping a gem when killed.

    private Transform player;
    private float nextAttackTime;
    private HealthSystem healthSystem;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthSystem = GetComponent<HealthSystem>();

        healthSystem.OnDeath += DropGem;  // Subscribe to the death event.

        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }

        if (healthSystem == null)
        {
            Debug.LogError("HealthSystem not attached to the enemy!");
        }
    }

    private void Update()
    {
        MoveTowardsPlayer();

        if (Vector2.Distance(transform.position, player.position) < attackRange && Time.time >= nextAttackTime)
        {
            AttackPlayer();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // Sprite flipping logic
        bool isLeftOfPlayer = transform.position.x < player.position.x;

        if (isLeftOfPlayer && transform.localScale.x < 0 || !isLeftOfPlayer && transform.localScale.x > 0)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;  // flip the sprite
            transform.localScale = currentScale;
        }
    }


    private void AttackPlayer()
    {
        Debug.Log($"{gameObject.name} is attacking the player at {Time.time}.");
        player.GetComponent<HealthSystem>().TakeDamage(damage);
    }

    public void TakeDamage(int damageAmount)
    {
        healthSystem.TakeDamage(damageAmount);
    }

    private void DropGem()
    {
        if (Random.value <= dropRate)
        {
            int randomGemIndex = Random.Range(0, gemPrefabs.Length);
            Instantiate(gemPrefabs[randomGemIndex], transform.position, Quaternion.identity);
        }
    }
}
