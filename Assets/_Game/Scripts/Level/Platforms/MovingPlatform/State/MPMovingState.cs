using UnityEngine;

public class MPMovingState : MPState
{
    public MPMovingState(MovingPlatformController context) : base(context) { }

    public override void FixedDo()
    {
        Context.transform.position = Vector2.MoveTowards(
            Context.transform.position,
            Context.CurrentTarget,
            Context.Speed * Time.fixedDeltaTime
        );

        if (new Vector2(Context.transform.position.x, Context.transform.position.y) == Context.CurrentTarget)
        {
            IsComplete = true;
        }
    }
}