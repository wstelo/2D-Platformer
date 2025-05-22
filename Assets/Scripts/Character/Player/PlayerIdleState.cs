using UnityEngine;

public class PlayerIdleState : State
{
    private Animator _animator;
    private Player _characterController;

    public PlayerIdleState(StateMachine stateMachine, Animator animator, Player character) : base(stateMachine)
    {
        _animator = animator;
        _characterController = character;
    }

    public override void Enter()
    {
        _animator.Play(PlayerAnimationData.Parameters.Idle);
    }

    public override void Update()
    {
        if (_characterController.HorizontalDirection != 0)
        {
            stateMachine.SetState<PlayerMoveState>();
        }
        if (_characterController.IsGround && _characterController.IsJump && _characterController.HorizontalDirection == 0)
        {
            stateMachine.SetState<PlayerJumpState>();
        }
    }
}
