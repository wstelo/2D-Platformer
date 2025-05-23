using UnityEngine;

public class EnemyPatrolState : State
{
    private PointCollector _patrolPointsCollector;
    private AnimatorController _animator;
    private Transform _currentTarget;
    private Mover _mover;
    private int _currentTargetIndex = 0;
    private bool _isCome = false;
    private float _distanceToTarget = 1f;
    private float _moveSpeed;

    public EnemyPatrolState(StateMachine stateMachine, PointCollector patrolPoints, AnimatorController animator, Mover mover, float moveSpeed) : base(stateMachine)
    {
        _patrolPointsCollector = patrolPoints;
        _animator = animator;
        _mover = mover;
        _moveSpeed = moveSpeed;
    }

    public override void Enter()
    {
        _isCome = false;
        _animator.StartRunAnimation();
        _currentTarget = GetNextPoint();
    }

    public override void Update()
    {
        if (_mover.transform.position.IsEnoughClose(_currentTarget.position, _distanceToTarget))
        {
            _isCome = true;
            _mover.ResetDirection();
            StateMachine.SetState<EnemyCheckAreaState>();
        }
    }

    public override void FixedUpdate()
    {
        if( _isCome == false)
        {
            Vector3 direction = _currentTarget.transform.position - _mover.transform.position;

            if (direction.x > 0)
            {
                direction.x = 1;
            }
            else if (direction.x < 0)
            {
                direction.x = -1;
            }

            _mover.SetDirection(direction.x);          
            _mover.Move(direction, _moveSpeed);
        }
    }

    public override void Exit()
    {
        _animator.StopRunAnimation();
    }

    private Transform GetNextPoint()
    {
        _currentTargetIndex = (++_currentTargetIndex) % _patrolPointsCollector.TargetPoints.Count;

        return _patrolPointsCollector.TargetPoints[_currentTargetIndex];
    }
}
