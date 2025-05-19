using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action <Coin> CoinDetected;
    public event Action Lended;

    public bool IsGrounded { get; private set; } = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            IsGrounded = true;
            Lended?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            IsGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            CoinDetected?.Invoke(coin);
        }
    }
}
