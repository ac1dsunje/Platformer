using System;

public class PlayerStats
{
    public int MaxHealth { get; private set; }
    public int Health { get; private set; }

    public event Action OnDied;
    public event Action<int, int> OnTakeHit;

    public float MoveSpeed { get; private set; }
    public float JumpForce { get; private set; }

    public int Coins { get; private set; }
    public event Action<int> OnCoinAdded;

    public PlayerStats(HealthConfig healthConfig, MovementConfig movementConfig)
    {
        MaxHealth = healthConfig.MaxHealth;
        Health = healthConfig.MaxHealth;

        MoveSpeed = movementConfig.MovementSpeed;
        JumpForce = movementConfig.JumpForce;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Health = 0;
            OnDied?.Invoke();
            return;
        }
        OnTakeHit?.Invoke(Health, MaxHealth);
    }

    public void AddCoins(int value)
    {
        Coins += value;
        OnCoinAdded?.Invoke(Coins);
    }
}