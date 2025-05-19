using UnityEngine;

[RequireComponent (typeof(CollisionDetector))]
public class CoinCollector : MonoBehaviour
{
    private CollisionDetector _collisionDetector;
    private int _count = 0;

    private void Awake()
    {
        _collisionDetector = GetComponent<CollisionDetector>();
    }

    private void OnEnable()
    {
        _collisionDetector.CoinDetected += IncreaseCount;
    }

    private void OnDisable()
    {
        _collisionDetector.CoinDetected -= IncreaseCount;
    }

    private void IncreaseCount(Coin coin)
    {
        _count++;
        Debug.Log(_count);
    }
}
