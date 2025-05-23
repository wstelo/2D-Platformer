using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(AnimatorController), typeof(Mover))]
public class Player : Character
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForceVertical;
    [SerializeField] private float _jumpForceHorizontal;

    private Rigidbody2D _rigidbody;
    private AnimatorController _animatorController;
    private StateMachine _stateMachine;
    private Mover _mover;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _mover = GetComponent<Mover>();
        _animatorController = GetComponent<AnimatorController>();

        _stateMachine = new StateMachine();
        _stateMachine.AddState(new PlayerIdleState(_stateMachine, _animatorController, _mover,_groundChecker,_inputService));
        _stateMachine.AddState(new PlayerMoveState(_stateMachine, _animatorController, _moveSpeed, _mover, _groundChecker, _inputService));
        _stateMachine.AddState(new PlayerJumpState(_stateMachine, _animatorController, _rigidbody, _jumpForceVertical, _jumpForceHorizontal, _mover ,_groundChecker, _inputService));
        _stateMachine.SetState<PlayerIdleState>();      
    }

    private void Update()
    {
        _mover.SetDirection(_inputService.Horizontal);
        _stateMachine?.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine?.FixedUpdate();
    }
}
