using UnityEngine;


public class EnemyPatrolState : State
{
    private PointCollector _patrolPointsCollector;
    private Animator _animator;
    private Transform _currentTarget;
    private Mover _mover;
    private Character _character;
    private int _currentTargetIndex = 0;
    private bool _isCome = false;
    private float _distanceToTarget = 1f;
    private float _moveSpeed;

    public EnemyPatrolState(StateMachine stateMachine, PointCollector patrolPoints, Animator animator, Mover enemyMover,Character character, float moveSpeed) : base(stateMachine)
    {
        _patrolPointsCollector = patrolPoints;
        _animator = animator;
        _mover = enemyMover;
        _moveSpeed = moveSpeed;
        _character = character;
    }

    public override void Enter()
    {
        _isCome = false;
        _animator.Play(PlayerAnimationData.Parameters.Run);
        _currentTarget = GetNextPoint();
    }

    public override void Update()
    {
        if (_mover.transform.position.IsEnoughClose(_currentTarget.position, _distanceToTarget))
        {
            _isCome = true;
            _character.ResetDirection();
            stateMachine.SetState<EnemyCheckAreaState>();
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

            _character.SetDirection(direction.x);          
            _mover.Move(direction, _moveSpeed);
        }
    }

    private Transform GetNextPoint()
    {
        _currentTargetIndex = (++_currentTargetIndex) % _patrolPointsCollector.TargetPoints.Count;

        return _patrolPointsCollector.TargetPoints[_currentTargetIndex];
    }
}
