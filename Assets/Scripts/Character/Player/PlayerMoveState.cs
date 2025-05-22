using UnityEngine;

public class PlayerMoveState : State
{
    private Animator _animator;
    private float _moveSpeed;
    private Player _characterController;
    private Mover _mover;

    public PlayerMoveState(StateMachine stateMachine, Animator animator, float moveSpeed, Player characterController, Mover mover) : base(stateMachine)
    {
        _animator = animator;
        _moveSpeed = moveSpeed;
        _characterController = characterController;
        _mover = mover;
    }

    public override void Enter()
    {
        _animator.Play(PlayerAnimationData.Parameters.Run);
    }

    public override void Update()
    {
        if(_characterController.IsGround && _characterController.IsJump)
        {
            stateMachine.SetState<PlayerJumpState>();
        }

        if(_characterController.HorizontalDirection == 0)
        {
            stateMachine.SetState<PlayerIdleState>();
        }
    }

    public override void FixedUpdate()
    {
        if (_characterController.IsGround)
        {
            _mover.Move(new Vector3(_characterController.HorizontalDirection * _moveSpeed, _characterController.transform.position.y));
        }
    }
}
