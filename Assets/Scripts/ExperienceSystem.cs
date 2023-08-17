using UnityEngine;
using UnityEngine.Events;

public class ExperienceSystem : MonoBehaviour
{
    public int CurrentLevel { get; private set; } = 1;
    public float CurrentXP { get; private set; } = 0;

    [SerializeField]
    public UnityEvent OnLevelUp;
    [SerializeField]
    public UnityEvent OnXPChanged;

    public void AddXP(float amount)
    {
        CurrentXP += amount;

        while (CurrentXP >= GetXPForNextLevel())
        {
            CurrentXP -= GetXPForNextLevel();
            LevelUp();
        }

        OnXPChanged?.Invoke();
    }

    public float GetXPForNextLevel()
    {
        return 100 * Mathf.Pow(1.10f, CurrentLevel - 1);
    }

    private void LevelUp()
    {
        CurrentLevel++;
        OnLevelUp?.Invoke();
    }
}
