using UnityEngine;

public class PlayerMoveState : State
{
    private AnimatorController _animator;
    private float _moveSpeed;
    private Mover _mover;
    private GroundChecker _groundChecker;
    private InputService _inputService;

    public PlayerMoveState(StateMachine stateMachine, AnimatorController animator, float moveSpeed, Mover mover, GroundChecker groundChecker, InputService inputService) : base(stateMachine)
    {
        _animator = animator;
        _moveSpeed = moveSpeed;
        _mover = mover;
        _groundChecker = groundChecker;
        _inputService = inputService;
    }

    public override void Enter()
    {
        _animator.StartRunAnimation();
    }

    public override void Update()
    {
        if(_groundChecker.IsGrounded && _inputService.IsJump)
        {
            StateMachine.SetState<PlayerJumpState>();
        }

        if(_mover.HorizontalDirection == 0)
        {
            StateMachine.SetState<PlayerIdleState>();
        }
    }

    public override void FixedUpdate()
    {
        if (_groundChecker.IsGrounded)
        {
            _mover.Move(new Vector3(_mover.HorizontalDirection * _moveSpeed, _mover.transform.position.y));
        }
    }

    public override void Exit()
    {
        _animator.StopRunAnimation();
    }
}
