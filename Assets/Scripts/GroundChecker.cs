using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _pointPositionY = - 0.3f;
    [SerializeField] private float _rayRadius = 0.3f;
    private Vector2 drawPoint;

    public bool IsGrounded { get; private set; } = false;


    private void Update()
    {
        CheckGroundCollision();
    }

    private void CheckGroundCollision()
    {
        drawPoint = transform.position + new Vector3(0, _pointPositionY);
        Collider2D hit = Physics2D.OverlapCircle(drawPoint, _rayRadius,_groundLayer);
        IsGrounded = hit != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + new Vector3(0, _pointPositionY), _rayRadius);
    }
}
