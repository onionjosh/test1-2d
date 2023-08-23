using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Base (initial) values
    public float baseMaxHealth = 100f;
    public float baseRecovery = 0f;
    public int baseArmor = 0;
    public float baseMoveSpeed = 100f;
    public float baseDamageMod = 100f;
    public float baseAttackRate = 100f;
    public float baseArea = 100f;
    public float baseSpeed = 100f;
    public float baseDuration = 100f;
    public int baseMagnet = 30;
    public float baseLuck = 100f;
    public float baseGrowth = 100f;
    public float baseMoney = 100f;
    public int baseRevival = 0;



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


    public static PlayerStats Instance { get; private set; }
    private void Awake()
    {
        // Ensure that there is only one instance of PlayerStats
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This makes sure the object stays when changing scenes
        }
        else
        {
            Destroy(gameObject); // This destroys the duplicate PlayerStats object
        }
    }


    private void Start()
    {
        ResetToBase();
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

    public void ResetToBase()
    {
        // Reset all the player stats to their initial base values
        // This is called when we need the player to return to a 'fresh' state (e.g., new level or new game)

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

}
