using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Base (initial) values
    private float baseMaxHealth = 100f;
    private float baseRecovery = 0f;
    private int baseArmor = 0;
    private float baseMoveSpeed = 100f;
    private float baseDamageMod = 100f;
    private float baseAttackRate = 100f;
    private float baseArea = 100f;
    private float baseSpeed = 100f;
    private float baseDuration = 100f;
    private int baseMagnet = 30;
    private float baseLuck = 100f;
    private float baseGrowth = 100f;
    private float baseMoney = 100f;
    private int baseRevival = 0;

    // Current values (modifiable during a game run)
    public float MaxHealth { get; protected set; }
    public float Recovery { get; protected set; }
    public int Armor { get; protected set; }
    public float MoveSpeed { get; protected set; }
    public float DamageMod { get; protected set; }
    public float AttackRate { get; protected set; }
    public float Area { get; protected set; }
    public float Speed { get; protected set; }
    public float Duration { get; protected set; }
    public int Magnet { get; protected set; }
    public float Luck { get; protected set; }
    public float Growth { get; protected set; }
    public float Money { get; protected set; }
    public int Revival { get; protected set; }

    private void Start()
    {
        ResetToBase();
    }

    public void ResetToBase()
    {
        MaxHealth = baseMaxHealth;
        Recovery = baseRecovery;
        Armor = baseArmor;
        MoveSpeed = baseMoveSpeed;
        DamageMod = baseDamageMod;
        AttackRate = baseAttackRate;
        Area = baseArea;
        Speed = baseSpeed;
        Duration = baseDuration;
        Magnet = baseMagnet;
        Luck = baseLuck;
        Growth = baseGrowth;
        Money = baseMoney;
        Revival = baseRevival;
    }

    public void ApplyMaxHealthMod(float value)
    {
        MaxHealth += value;
    }

    public void ApplyRecovery(float value)
    {
        Recovery += value;
    }

    public void ApplyArmor(int value)
    {
        Armor += value;
    }

    public void ApplyMoveSpeed(float value)
    {
        MoveSpeed += value;
    }

    public void ApplyDamageMod(float value)
    {
        DamageMod += value;
    }

    public void ApplyAttackRate(float value)
    {
        AttackRate += value;
    }

    public void ApplyArea(float value)
    {
        Area += value;
    }

    public void ApplySpeed(float value)
    {
        Speed += value;
    }

    public void ApplyDuration(float value)
    {
        Duration += value;
    }

    public void ApplyMagnet(int value)
    {
        Magnet += value;
    }

    public void ApplyLuck(float value)
    {
        Luck += value;
    }

    public void ApplyGrowth(float value)
    {
        Growth += value;
    }

    public void ApplyMoney(float value)
    {
        Money += value;
    }

    public void ApplyRevival(int value)
    {
        Revival += value;
    }
}
