using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Inventory playerInventory;
    public PlayerStats playerStats;

    public GameState currentState = GameState.MainMenu;
    public GameObject deathMenuUI; // Drag your Death Menu UI here

    private void Start()
    {
        Debug.Log("GameManager Started");
        // Initially hide the death menu
        deathMenuUI.SetActive(false);

        // Subscribe to player's OnDeath event
        HealthSystem playerHealth = FindObjectOfType<Player>().GetComponent<HealthSystem>();
        if (playerHealth)
            playerHealth.OnDeath += HandlePlayerDeath;

        Time.timeScale = 1f;
    }

    public enum GameState
    {
        MainMenu,
        Playing,
        GameOver
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
        currentState = GameState.Playing;
        
        // Reset and initialize game properties here
        ResetPlayerForNewRun();

        // Hide the death menu
        deathMenuUI.SetActive(false);
        
        // Resume game time
        Time.timeScale = 1f;
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                // Make sure the death UI is off
                deathMenuUI.SetActive(false);
                break;
                
            case GameState.Playing:
                // Again, ensure the death UI is off during gameplay
                deathMenuUI.SetActive(false);
                break;
                
            case GameState.GameOver:
                // Here, you'd activate the death UI
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

    public void EndGame()
    {
        Debug.Log("EndGame Called");
        // Reset all owned passive items to their base stats
        foreach (PassiveItem item in playerInventory.ownedPassiveItems)
        {
            item.ResetToBase();
        }

        // Reset all owned weapons to their base stats
        foreach (Weapon weapon in playerInventory.ownedWeapons)
        {
            weapon.ResetToBase();
        }
        
        // Any other logic like analytics or updates can be added here
    }

    public void ResetPlayerForNewRun()
    {
        // Clear the player's inventory
        playerInventory.ownedPassiveItems.Clear();
        playerInventory.ownedWeapons.Clear();

        // Reset the player's stats to base level
        playerStats.ResetToBase();

        // ... any other reset logic ...
    }

    public void RestartGame()
    {
        // This function will restart the scene, which in turn resets everything
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        HealthSystem playerHealth = FindObjectOfType<Player>()?.GetComponent<HealthSystem>();
        if (playerHealth)
            playerHealth.OnDeath -= HandlePlayerDeath;
    }

}
