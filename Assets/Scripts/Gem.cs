using UnityEngine;

public class Gem : MonoBehaviour
{
    public enum GemType { Blue, Green, Orange, Red, Rainbow }

    public GemType gemType;
    public float xpValue;

    private void Start()
    {
        switch (gemType)
        {
            case GemType.Blue:
                xpValue = 10;
                break;
            case GemType.Green:
                xpValue = 100;
                break;
            case GemType.Orange:
                xpValue = 500;
                break;
            case GemType.Red:
                xpValue = 1000;
                break;
            case GemType.Rainbow:
                xpValue = 10000;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something collided with the gem.");

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collided with the gem.");

            ExperienceSystem playerXP = collision.GetComponent<ExperienceSystem>();
            if (playerXP != null)
            {
                playerXP.AddXP(xpValue);
            }

            Destroy(gameObject);
        }
    }

}