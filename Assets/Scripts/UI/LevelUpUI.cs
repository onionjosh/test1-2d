using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpUI : MonoBehaviour
{
    public GameObject levelUpPanel; // Drag the panel you created in the editor here
    public TextMeshProUGUI[] optionTexts; // Drag the 3 text objects representing each option's description
    public GameManager gameManager; // Reference to your GameManager script

    private void Start()
    {
        levelUpPanel.SetActive(false); // Make sure the panel is off when starting
    }

    public void ShowLevelUpOptions()
    {
        // Get random items/weapons and populate the UI
        PopulateOptions();

        // Show the panel
        levelUpPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }

    private void PopulateOptions()
    {
        // Assume that gameManager.playerInventory.availableWeapons and availablePassiveItems are lists of Weapons and PassiveItems
        for (int i = 0; i < optionTexts.Length; i++)
        {
            // Here, randomly select from availableWeapons and availablePassiveItems
            // Set optionTexts[i].text accordingly
        }
    }


    public void OnOptionSelected(int optionIndex)
    {
        // Add/upgrade the selected item or weapon in the inventory
        // Use the optionIndex to determine which option was clicked (0, 1, or 2)

        // Close the panel
        levelUpPanel.SetActive(false);

        // Resume the game
        Time.timeScale = 1f;
    }
}
