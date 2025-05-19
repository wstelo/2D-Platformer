using UnityEngine;

public class EnemyAreaCollector : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private PatrolPointCollector _patrolCollector;

    private void Awake()
    {
        SpawnPoint = _spawnPoint;
        PatrolPoints = _patrolCollector;
    }

    public Transform SpawnPoint { get; private set; } 
    public PatrolPointCollector PatrolPoints { get; private set; }
}
