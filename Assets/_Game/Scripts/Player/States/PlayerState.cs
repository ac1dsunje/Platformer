public class PlayerState : State
{
    private PlayerController _context;

    public PlayerState(PlayerController context)
    {
        _context = context;
    }
}