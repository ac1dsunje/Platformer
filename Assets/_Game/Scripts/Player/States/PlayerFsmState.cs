using _Game.Scripts.FSM;

namespace _Game.Scripts.Player.States
{
public abstract class PlayerFsmState : FsmState
{
    private PlayerController _context;

    protected PlayerFsmState(PlayerController context)
    {
        _context = context;
    }
}
}