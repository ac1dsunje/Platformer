using System;

public class PlayerPresenter: IDisposable
{
    private readonly PlayerModel _model;
    private readonly InputHandler _input;

    public PlayerPresenter(PlayerModel model, InputHandler input)
    {
        _model = model;
        _input = input;

        _input.OnJumpRequested += SetJumpRequest;
        _input.OnHorizontalInput += SetVelocity;
    }

    public void SetGroundState(bool state)
    {
        _model.SetOnGroundState(state);
    }

    private void SetJumpRequest()
    {
        _model.RequestJump();
    }

    private void SetVelocity(float value)
    {
        _model.SetVelocity(value);
    }

    public void Dispose()
    {
        _input.OnJumpRequested -= SetJumpRequest;
        _input.OnHorizontalInput -= SetVelocity;
    }
}