using UnityEngine;

public class PlayerJumpState : State
{
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private Player _characterController;
    private float _jumpForceVertical;
    private float _jumpForceHorizontal;

    public PlayerJumpState(StateMachine stateMachine, Animator animator, Rigidbody2D rigidBody, Player characterController, float jumpForceVertical, float jumpForceHorizontal) : base(stateMachine)
    {
        _animator = animator;
        _characterController = characterController;
        _rigidBody = rigidBody;
        _jumpForceVertical = jumpForceVertical;
        _jumpForceHorizontal = jumpForceHorizontal;
    }

    public override void Enter()
    {
        _animator.Play(PlayerAnimationData.Parameters.Jump);
    }

    public override void Update()
    {
        if(_characterController.IsGround == false)
        {
            _characterController.Landed();
        }

        if(_characterController.IsGround &&  _characterController.IsJump == false )
        {
            if( _characterController.HorizontalDirection == 0)
            {
                stateMachine.SetState<PlayerIdleState>();
            }
            else
            {
                stateMachine.SetState<PlayerMoveState>();
            }
        }
    }

    public override void FixedUpdate()
    {
        if (_characterController.IsGround && _characterController.IsJump)
        {
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.AddForce(new Vector2(_characterController.HorizontalDirection * _jumpForceHorizontal, _jumpForceVertical));
        }
    }
}
