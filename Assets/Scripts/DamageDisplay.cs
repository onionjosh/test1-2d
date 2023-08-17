using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageDisplay : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject canvasGameObject;    // Assign your main canvas here

    public float decayRate = 0.5f; // Speed at which text shrinks and fades
    public int initialFontSize = 50;

    private void Awake()
{
    if(!canvasGameObject)
        canvasGameObject = GameObject.Find("Canvas");
}

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
  
   

}

