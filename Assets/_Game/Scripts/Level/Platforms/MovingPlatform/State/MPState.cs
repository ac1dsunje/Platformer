namespace _Game.Scripts.Level.Platforms.MovingPlatform.State
{
public abstract class MpState: global::_Game.Scripts.FSM.State
{
    protected readonly MovingPlatformController Platform;

    protected MpState(MovingPlatformController platform)
    {
        Platform = platform;
    }
}
}