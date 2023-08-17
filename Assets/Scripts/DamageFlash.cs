using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class DamageFlash : MonoBehaviour
{
    public float flashDuration = 0.1f;
    public int flashTimes = 3;  // Number of times to flash
    public Color flashColor = new Color(1, 0, 0, 1); // Flash red by default

    private SpriteRenderer spriteRenderer;  // <-- Make sure this line is here
    private Color originalColor;

    private Coroutine flashCoroutine;  // Reference to the currently running coroutine

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Flash()
    {
        // If there's an ongoing flash, stop it
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        // Start a new flash
        flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        for (int i = 0; i < flashTimes; i++)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }

        // Set the flashCoroutine to null after finishing to indicate no ongoing flash
        flashCoroutine = null;
    }
}
