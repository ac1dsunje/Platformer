public class PlayerModel
{
    public float MaxHealth { get; }
    public float Health { get; }

    public float MoveSpeed { get; }
    public float JumpForce { get; }

    public PlayerModel(HealthConfig healthConfig, MovementConfig movementConfig)
    {
        MaxHealth = healthConfig.MaxHealth;
        Health = healthConfig.MaxHealth;

        MoveSpeed = movementConfig.MovementSpeed;
        JumpForce = movementConfig.JumpForce;
    }
}