using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Weapon> ownedWeapons = new List<Weapon>();
    public List<PassiveItem> ownedPassiveItems = new List<PassiveItem>();

    public List<Weapon> availableWeapons; // Add this line to link available weapons
    public List<PassiveItem> availablePassiveItems; // Add this line to link available passive items


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

    public void OnLevelUpWeaponChosen(Weapon selectedWeapon)
    {
        if (ownedWeapons.Contains(selectedWeapon))
        {
            // Player already owns this weapon, so upgrade its rank
            selectedWeapon.UpgradeToNewRank();
        }
        else
        {
            // Player does not own this weapon, so add it to their inventory
            ownedWeapons.Add(selectedWeapon);
        }
    }


    public void AddRandomWeapon()
    {
        int randomIndex = UnityEngine.Random.Range(0, availableWeapons.Count);
        Weapon selectedWeapon = availableWeapons[randomIndex];
        ownedWeapons.Add(selectedWeapon);
    }

    public void AddRandomPassiveItem()
    {
        int randomIndex = UnityEngine.Random.Range(0, availablePassiveItems.Count);
        PassiveItem selectedItem = availablePassiveItems[randomIndex];
        ownedPassiveItems.Add(selectedItem);
    }

    // ... similar function can be written for Weapons
}
