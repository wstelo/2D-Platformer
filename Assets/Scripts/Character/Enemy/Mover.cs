using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 direction, float moveSpeed)
    {
        _rigidbody.velocity = direction * moveSpeed;
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction;
    }
}
