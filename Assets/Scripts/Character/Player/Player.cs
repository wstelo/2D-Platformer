using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(Animator), typeof(Mover))]
public class Player : Character
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForceVertical;
    [SerializeField] private float _jumpForceHorizontal;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private StateMachine _stateMachine;
    private Mover _mover;

    public bool IsJump { get; private set; } = false;
    public bool IsGround { get; private set; } = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();  
        _mover = GetComponent<Mover>();

        _stateMachine = new StateMachine();
        _stateMachine.AddState(new PlayerIdleState(_stateMachine, _animator, this));
        _stateMachine.AddState(new PlayerMoveState(_stateMachine, _animator, _moveSpeed, this, _mover));
        _stateMachine.AddState(new PlayerJumpState(_stateMachine, _animator, _rigidbody, this, _jumpForceVertical, _jumpForceHorizontal));
        _stateMachine.SetState<PlayerIdleState>();      
    }

    private void OnEnable()
    {
        _inputService.JumpButtonClicked += Jump;
    }

    private void OnDisable()
    {
        _inputService.JumpButtonClicked -= Jump;
    }

    private void Update()
    {
        IsGround = _groundChecker.IsGrounded;
        SetDirection(_inputService.Horizontal);
        _stateMachine?.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine?.FixedUpdate();
    }

    private void Jump()
    {
        IsJump = true;
    }

    public void Landed()
    {
        IsJump = false;
    }
}
