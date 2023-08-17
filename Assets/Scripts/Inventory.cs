using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Weapon> ownedWeapons = new List<Weapon>();
    public List<PassiveItem> ownedPassiveItems = new List<PassiveItem>();

    public void OnLevelUpItemChosen(PassiveItem selectedItem, PlayerStats playerStats)
    {
        if (ownedPassiveItems.Contains(selectedItem))
        {
            // Player already owns this item, so upgrade its rank
            selectedItem.UpgradeToNewRank(playerStats);
        }
        else
        {
            // Player does not own this item, so add it to their inventory
            ownedPassiveItems.Add(selectedItem);
        }
    }

    // ... similar function can be written for Weapons
}
