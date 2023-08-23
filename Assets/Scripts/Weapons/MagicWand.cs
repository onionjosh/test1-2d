using UnityEngine;

public class MagicWand : WeaponController
{
    public override void UpdateWeaponStats()
    {
        base.UpdateWeaponStats();
    }

    public override void FireProjectile(Vector2 direction)
    {
        base.FireProjectile(direction);
        //Debug.Log("magic wand script firing");
    }

}
