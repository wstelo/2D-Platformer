using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _prefab;
    [SerializeField] private List<EnemyAreaCollector> _spawnArea;

    private void Awake()
    {
        Instantiate(_prefab);
    }

    private void Instantiate(EnemyMover prefab)
    {
        for (int i = 0; i < _spawnArea.Count; i++)
        {
            var newEnemy = Instantiate(prefab, _spawnArea[i].SpawnPoint.position, Quaternion.identity);
            newEnemy.Initialize(_spawnArea[i].PatrolPoints);
        }
    }
}
