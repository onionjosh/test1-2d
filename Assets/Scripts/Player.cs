using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector3 originalScale = new Vector3(1f, 1f, 1f);

    private PlayerStats playerStats;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        
        // ... other code ...
    }

  private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        float moveSpeed = playerStats.MoveSpeed;

        Vector2 input = new Vector2(moveX, moveY);
        if (input.sqrMagnitude > 1)
        {
            input.Normalize();
        }

        rb2D.velocity = input * moveSpeed;

        if (moveX > 0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (moveX < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }
}
