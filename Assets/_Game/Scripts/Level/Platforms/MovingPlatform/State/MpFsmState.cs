namespace _Game.Scripts.Level.Platforms.MovingPlatform.State
{
public abstract class MpFsmState: FSM.FsmState
{
    protected readonly MovingPlatformController Platform;

    protected MpFsmState(MovingPlatformController platform)
    {
        Platform = platform;
    }
}
}