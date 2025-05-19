using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private PatrolPointCollector _objectWithPoints;
    private List<Transform> _spawnPoints = new List<Transform>();
    private Transform _currentTarget;
    private int _currentTargetIndex = 0;
    private bool _isCome = false;
    private float _timeToIdle = 3f;

    private void Start()
    {
        if (_objectWithPoints.TargetPoints.Count > 0)
        {
            foreach (var target in _objectWithPoints.TargetPoints)
            {
                _spawnPoints.Add(target);
            }

            _currentTarget = _spawnPoints[_currentTargetIndex];
        }
    }

    private void Update()
    {
         Move();
    }

    public void Initialize(PatrolPointCollector points)
    {
        _objectWithPoints = points;
    }

    private IEnumerator Patrol()
    {
        var wait = new WaitForSeconds(_timeToIdle);

        yield return wait;

        _isCome = false;
    }

    private void Move()
    {
        float distanceToTarget = 0.5f;

        if (transform.position.IsEnoughClose(_currentTarget.position, distanceToTarget))
        {
            _isCome = true;
            _currentTarget = GetNextPoint();
            StartCoroutine(Patrol());
        }

        if(_isCome == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
        }
    }

    private Transform GetNextPoint()
    {
        _currentTargetIndex = (++_currentTargetIndex) % _spawnPoints.Count;

        return _spawnPoints[_currentTargetIndex];
    }
}
