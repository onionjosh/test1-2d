using UnityEngine;
using UnityEngine.UI;

public class XPUI : MonoBehaviour
{
    public ExperienceSystem experienceSystem;
    public Slider xpSlider;
    public Text levelText;
    public LevelUpUI levelUpUI; // Reference to the LevelUpUI script

    private void Start()
    {
        experienceSystem.OnXPChanged.AddListener(UpdateXPUI);
        experienceSystem.OnLevelUp.AddListener(UpdateLevelUI);
    }

    private void UpdateXPUI()
    {
        float progress = experienceSystem.CurrentXP / experienceSystem.GetXPForNextLevel();
        xpSlider.value = progress; // This sets the fill amount of the XP bar based on the player's progress to the next level.
    }

    private void UpdateLevelUI()
    {
        levelText.text = "Level: " + experienceSystem.CurrentLevel;
        levelUpUI.ShowLevelUpOptions();  // Now you can call methods from LevelUpUI
    }
}
