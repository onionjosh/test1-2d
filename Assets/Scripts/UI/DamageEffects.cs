using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageEffects : MonoBehaviour
{
    // Damage Display Variables
    public GameObject damageTextPrefab;
    public GameObject canvasGameObject;
    public float decayRate = 0.5f;
    public int initialFontSize = 50;

    // Damage Flash Variables
    public float flashDuration = 0.1f;
    public int flashTimes = 3;
    public Color flashColor = new Color(1, 0, 0, 1);

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine flashCoroutine;

    private void Awake()
    {
        // Initialize Damage Flash
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        // Initialize Damage Display
        if (!canvasGameObject)
            canvasGameObject = GameObject.Find("Canvas");
    }

    // Damage Display Methods

    public void DisplayDamage(int damage, Vector3 position)
    {
        if (!damageTextPrefab) Debug.LogError("Damage Text Prefab is missing!");
        if (!canvasGameObject) Debug.LogError("Canvas GameObject is missing!");

        GameObject textInstance = Instantiate(damageTextPrefab, canvasGameObject.transform);
        if (!textInstance) Debug.LogError("Failed to instantiate damage text prefab.");

        textInstance.transform.position = Camera.main.WorldToScreenPoint(position);
        Text textComponent = textInstance.GetComponentInChildren<Text>();

        if (!textComponent) Debug.LogError("Text Component is missing on instantiated object.");

        textComponent.text = "-" + damage.ToString();
        textComponent.fontSize = initialFontSize;
        StartCoroutine(DamageTextDecay(textComponent));
    }

    private IEnumerator DamageTextDecay(Text damageText)
    {
        while (damageText.fontSize > 0)
        {
            damageText.fontSize -= (int)(initialFontSize * decayRate * Time.deltaTime);
            damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, damageText.color.a - decayRate * Time.deltaTime);
            yield return null;
        }

        Destroy(damageText.gameObject);
    }

    // Damage Flash Methods

    public void Flash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

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

        flashCoroutine = null;
    }
}
