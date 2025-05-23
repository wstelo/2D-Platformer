using UnityEngine;

public class EnemyCheckAreaState : State
{
    private AnimatorController _animator;
    private Rotator _rotator;
    private float _timeToIdle;
    private float _timeToRotate = 1;
    private float _remainingTimeToRotate;
    private float _remainingTimeToNextState;

    public EnemyCheckAreaState(StateMachine stateMachine, AnimatorController animator, float timeToIdle, Rotator rotator) : base(stateMachine)
    {
        _animator = animator;
        _timeToIdle = timeToIdle;
        _rotator = rotator;
    }

    public override void Enter()
    {
        _remainingTimeToRotate = _timeToRotate;
        _remainingTimeToNextState = _timeToIdle;
        _animator.StartIdleAnimation();
    }

    public override void Update()
    {
        _remainingTimeToNextState -= Time.deltaTime;
        _remainingTimeToRotate -= Time.deltaTime;

        if (_remainingTimeToRotate < 0)
        {
            _rotator.RotateCharacter();
            _remainingTimeToRotate = _timeToRotate;
        }

        if(_remainingTimeToNextState < 0)
        {
            StateMachine.SetState<EnemyPatrolState>();
        }
    }

    public override void Exit()
    {
        _animator.StopIdleAnimation();
    }
}
