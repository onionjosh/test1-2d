using UnityEngine;
using System.Collections.Generic;

public class PlayerWeaponManager : MonoBehaviour
{
    public List<WeaponController> equippedWeapons = new List<WeaponController>();

    private void Update()
    {
        foreach (WeaponController weapon in equippedWeapons)
        {
            weapon.UpdateWeapon();
        }
    }

    public void AddWeapon(Weapon weaponData, GameObject projectilePrefab)
    {
        WeaponController newWeapon = new WeaponController(this.transform, weaponData, projectilePrefab);
        equippedWeapons.Add(newWeapon);
    }

    public void RemoveWeapon(WeaponController weapon)
    {
        equippedWeapons.Remove(weapon);
    }
}
