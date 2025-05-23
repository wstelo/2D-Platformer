using UnityEngine;

[RequireComponent(typeof(CoinWallet))]
public class CollisionDetector : MonoBehaviour
{
    private CoinWallet _coinCollector;

    private void Awake()
    {
        _coinCollector = GetComponent<CoinWallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            {
                coin.DisableObject();
                _coinCollector.IncreaseCount();
            }
    }
}
