using UnityEngine;

public class PlayerIdleState : State
{
    private AnimatorController _animator;
    private Mover _mover;
    private GroundChecker _groundChecker;
    private InputService _inputService;

    public PlayerIdleState(StateMachine stateMachine, AnimatorController animator, Mover mover, GroundChecker groundChecker, InputService inputService) : base(stateMachine)
    {
        _animator = animator;
        _mover = mover;
        _groundChecker = groundChecker;
        _inputService = inputService;
    }

    public override void Enter()
    {
        _animator.StartIdleAnimation();
    }

    public override void Update()
    {
        if (_mover.HorizontalDirection != 0)
        {
            StateMachine.SetState<PlayerMoveState>();
        }
        if (_groundChecker.IsGrounded && _inputService.IsJump && _mover.HorizontalDirection == 0)
        {
            StateMachine.SetState<PlayerJumpState>();
        }
    }

    public override void Exit()
    {
        _animator.StopIdleAnimation();
    }
}
