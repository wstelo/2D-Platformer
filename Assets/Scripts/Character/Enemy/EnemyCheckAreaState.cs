using System.Collections;
using UnityEngine;

public class EnemyCheckAreaState : State
{
    private Animator _animator;
    private Timer _timer;
    private Rotator _rotator;
    private float _timeToIdle;
    private float _timeToRotate = 1;
    private Coroutine _changeStateCoroutine;
    private Coroutine _changeRotationCoroutine;

    public EnemyCheckAreaState(StateMachine stateMachine, Animator animator, float timeToIdle, Timer timer, Rotator rotator) : base(stateMachine)
    {
        _animator = animator;
        _timeToIdle = timeToIdle;
        _timer = timer;
        _rotator = rotator;
    }

    public override void Enter()
    {
        _animator.Play(EnemyAnimationData.Parameters.Idle);
         _changeStateCoroutine = _timer.StartCoroutine(SetNextState());
        _changeRotationCoroutine = _timer.StartCoroutine(Rotate());
    }

    public override void Exit()
    {
        _timer.StopCoroutine(_changeStateCoroutine);
        _timer.StopCoroutine(_changeRotationCoroutine);
    }

    public IEnumerator SetNextState()
    {
        var waitToChangeState = new WaitForSeconds(_timeToIdle);

        yield return waitToChangeState;

        stateMachine.SetState<EnemyPatrolState>();
    }

    public IEnumerator Rotate()
    {
        var waitToRotate = new WaitForSeconds(_timeToRotate);

        while (true)
        {          
            yield return waitToRotate;

            _rotator.RotateCharacter();
        }
    }
}
