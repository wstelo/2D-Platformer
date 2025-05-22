using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _rayDistance = 0.3f;

    public bool IsGrounded { get; private set; } = false;

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, _groundLayer);
        IsGrounded = hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * _rayDistance);
    }
}
