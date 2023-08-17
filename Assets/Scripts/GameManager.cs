using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Inventory playerInventory;
    public PlayerStats playerStats;

    public void EndGame()
    {
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

        // ... any other end of game logic (e.g., show a 'Game Over' screen) ...
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
}
