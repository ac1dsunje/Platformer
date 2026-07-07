public abstract class MPState: State
{
    protected MovingPlatformController Platform;

    public MPState(MovingPlatformController platform)
    {
        Platform = platform;
    }
}