using UnityEngine;

public class MPMovingState : MPState
{
    public MPMovingState(MovingPlatformController context) : base(context) { }

    public override void FixedDo()
    {
        Vector2 newPosition = Vector2.MoveTowards(
            Context.RigidBody.position,
            Context.CurrentTarget,
            Context.Speed * Time.fixedDeltaTime
        );
        Context.RigidBody.MovePosition(newPosition);

        if (Context.RigidBody.position == Context.CurrentTarget)
        {
            IsComplete = true;
        }
    }
}