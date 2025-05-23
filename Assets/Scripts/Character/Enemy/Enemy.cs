using UnityEngine;

[RequireComponent(typeof(Mover), typeof(AnimatorController))]
[RequireComponent (typeof(Rotator))]
public class Enemy : Character
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _timeToIdle = 3f;
    private PointCollector _patrolPointsCollector;
    private Mover _enemyMover;
    private StateMachine _stateMachine;
    private AnimatorController _animator;
    private Rotator _rotator;

    private void Awake()
    {
        _animator = GetComponent<AnimatorController>();
        _enemyMover = GetComponent<Mover>();
        _stateMachine = new StateMachine();
        _rotator = GetComponent<Rotator>();
    }

    private void Start()
    {
        _stateMachine.AddState(new EnemyPatrolState(_stateMachine, _patrolPointsCollector, _animator, _enemyMover, _moveSpeed));
        _stateMachine.AddState(new EnemyCheckAreaState(_stateMachine,_animator,_timeToIdle, _rotator));
        _stateMachine.SetState<EnemyPatrolState>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    public void Initialize(PointCollector points)
    {
        _patrolPointsCollector = points;
    }
}
