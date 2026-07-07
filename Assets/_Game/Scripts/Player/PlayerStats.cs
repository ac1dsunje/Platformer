using System;

public class PlayerStats
{
    public float MaxHealth { get; private set; }
    public float Health { get; private set; }

    public event Action OnDied;

    public float MoveSpeed { get; private set; }
    public float JumpForce { get; private set; }

    public int Coins { get; private set; }

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
        }
    }

    public void AddCoins(int value)
    {
        Coins += value;
    }
}