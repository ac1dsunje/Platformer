public abstract class MPState: State
{
    protected MovingPlatformController Context;

    public MPState(MovingPlatformController context)
    {
        Context = context;
    }
}