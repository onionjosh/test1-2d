using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI; // for using Button and Text
using System;

public class GameManager : MonoBehaviour
{
    public Inventory playerInventory;
    public PlayerStats playerStats;
    public GameObject LevelUpUI; // Drag your LevelUpUI GameObject here
    public LevelUpUI levelUpUI;
    public Button[] LevelUpButtons;  // Assuming 4 buttons

    public GameState currentState = GameState.MainMenu;
    public GameObject deathMenuUI;

    private void Start()
    {
        Debug.Log("GameManager Started");

        deathMenuUI.SetActive(false);

        HealthSystem playerHealth = FindObjectOfType<Player>().GetComponent<HealthSystem>();
        if (playerHealth)
            playerHealth.OnDeath += HandlePlayerDeath;

        ExperienceSystem playerXPSystem = FindObjectOfType<ExperienceSystem>();
        if (playerXPSystem)
        {
            playerXPSystem.OnLevelUp.AddListener(OnPlayerLevelUp);
        }

        // Disable LevelUpUI at start
        LevelUpUI.SetActive(false);

        Time.timeScale = 1f;
    }

    public enum GameState
    {
        MainMenu,
        Playing,
        GameOver
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                deathMenuUI.SetActive(false);
                break;

            case GameState.Playing:
                deathMenuUI.SetActive(false);
                break;

            case GameState.GameOver:
                deathMenuUI.SetActive(true);
                break;
        }
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player Died");
        currentState = GameState.GameOver;
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnPlayerLevelUp()
    {
        LevelUpUI.SetActive(true);
        Time.timeScale = 0f;
        // Defer to LevelUpUI to show options and capture user selection
        levelUpUI.ShowLevelUpOptions();
        PopulateLevelUpOptions();
    }

    private void PopulateLevelUpOptions()
    {
        // Populate the buttons with random options from available items and weapons
        for (int i = 0; i < LevelUpButtons.Length; i++)
        {
            // For demonstration purposes, we'll alternate between adding weapons and items
            if (i % 2 == 0) 
            {
                Weapon randomWeapon = playerInventory.availableWeapons[UnityEngine.Random.Range(0, playerInventory.availableWeapons.Count)];
                LevelUpButtons[i].GetComponentInChildren<Text>().text = randomWeapon.name;
                LevelUpButtons[i].onClick.RemoveAllListeners();
                LevelUpButtons[i].onClick.AddListener(() => AddWeaponToInventory(randomWeapon));
            }
            else 
            {
                PassiveItem randomItem = playerInventory.availablePassiveItems[UnityEngine.Random.Range(0, playerInventory.availablePassiveItems.Count)];
                LevelUpButtons[i].GetComponentInChildren<Text>().text = randomItem.name;
                LevelUpButtons[i].onClick.RemoveAllListeners();
                LevelUpButtons[i].onClick.AddListener(() => AddItemToInventory(randomItem));
            }
        }
    }

    private void AddItemToInventory(PassiveItem selectedItem)
    {
        if (playerInventory.ownedPassiveItems.Contains(selectedItem))
        {
            selectedItem.UpgradeToNewRank(playerStats);  // Now passing playerStats as an argument
        }
        else
        {
            playerInventory.ownedPassiveItems.Add(selectedItem);
        }

        LevelUpUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void AddWeaponToInventory(Weapon selectedWeapon)
    {
        if (playerInventory.ownedWeapons.Contains(selectedWeapon))
        {
            selectedWeapon.UpgradeToNewRank();  // No arguments here
        }
        else
        {
            playerInventory.ownedWeapons.Add(selectedWeapon);
        }

        LevelUpUI.SetActive(false);
        Time.timeScale = 1f;
    }


    private void OnDestroy()
    {
        ExperienceSystem playerXPSystem = FindObjectOfType<ExperienceSystem>();
        if (playerXPSystem)
        {
            playerXPSystem.OnLevelUp.RemoveListener(OnPlayerLevelUp);
        }

        HealthSystem playerHealth = FindObjectOfType<Player>()?.GetComponent<HealthSystem>();
        if (playerHealth)
        {
            playerHealth.OnDeath -= HandlePlayerDeath;
        }
    }
}
