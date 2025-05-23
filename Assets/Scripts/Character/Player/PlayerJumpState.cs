using UnityEngine;

public class PlayerJumpState : State
{
    private AnimatorController _animator;
    private Rigidbody2D _rigidBody;
    private float _jumpForceVertical;
    private float _jumpForceHorizontal;
    private Mover _mover;
    private GroundChecker _groundChecker;
    private InputService _inputService;

    public PlayerJumpState(StateMachine stateMachine, AnimatorController animator, Rigidbody2D rigidBody, float jumpForceVertical, float jumpForceHorizontal, Mover mover, GroundChecker groundChecker, InputService inputService) : base(stateMachine)
    {
        _animator = animator;
        _rigidBody = rigidBody;
        _jumpForceVertical = jumpForceVertical;
        _jumpForceHorizontal = jumpForceHorizontal;
        _mover = mover;
        _groundChecker = groundChecker;
        _inputService = inputService;
    }

    public override void Enter()
    {
        _animator.StartJumpAnimation();
    }

    public override void Update()
    {
        if(_groundChecker.IsGrounded && _inputService.IsJump == false )
        {
            if(_mover.HorizontalDirection == 0)
            {
                StateMachine.SetState<PlayerIdleState>();
            }
            else
            {
                StateMachine.SetState<PlayerMoveState>();
            }
        }
    }

    public override void FixedUpdate()
    {
        if (_groundChecker.IsGrounded && _inputService.IsJump)
        {
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.AddForce(new Vector2(_mover.HorizontalDirection * _jumpForceHorizontal, _jumpForceVertical));
        }
    }

    public override void Exit()
    {
        _animator.StopJumpAnimation();
    }
}
