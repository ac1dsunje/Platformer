using _Game.Scripts.FSM;

namespace _Game.Scripts.Player.States
{
public abstract class PlayerState : State
{
    private PlayerController _context;

    protected PlayerState(PlayerController context)
    {
        _context = context;
    }
}
}