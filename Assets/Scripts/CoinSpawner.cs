using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private SpawnPointCollector _objectWithPoints;
    [SerializeField] private CollisionDetector _collisionDetector;

    private void Awake()
    {
        Instantiate(_prefab);
    }

    private void OnEnable()
    {
        _collisionDetector.CoinDetected += Destroy;
    }

    private void OnDisable()
    {
        _collisionDetector.CoinDetected -= Destroy;
    }

    private void Instantiate(Coin coin)
    {
        for (int i = 0; i < _objectWithPoints.TargetPoints.Count; i++)
        {
            Instantiate(coin, _objectWithPoints.TargetPoints[i].transform.position, Quaternion.identity);
        }
    }

    private void Destroy(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}
