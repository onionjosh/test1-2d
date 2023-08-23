using UnityEngine;

public class Fireball : WeaponController
{

    public int numberOfProjectiles = 3; // Number of projectiles in the spread
    public float spreadAngle = 15f; // Angle between each projectile in the spread


    public override void UpdateWeaponStats()
    {
        base.UpdateWeaponStats();
    }

    public override void FireProjectile(Vector2 direction)
    {
        // Calculate the rotation step for each projectile
        float step = spreadAngle / (numberOfProjectiles - 1);
        
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float spreadOffset = -spreadAngle / 2 + step * i; // Calculate the angle offset
            Vector2 rotatedDirection = RotateVector(direction, spreadOffset); // Rotate the direction vector
            base.FireProjectile(rotatedDirection); // Fire using the rotated direction
        }
    }


    private Vector2 RotateVector(Vector2 vector, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radian);
        float cos = Mathf.Cos(radian);
        
        float tx = vector.x;
        float ty = vector.y;
        
        return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
    }


}
