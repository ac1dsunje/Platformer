using System;

public class PlayerStats
{
    public float MaxHealth { get; private set; }
    public float Health { get; private set; }

    public float MoveSpeed { get; private set; }
    public float JumpForce { get; private set; }

    public event Action OnDied;

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
}