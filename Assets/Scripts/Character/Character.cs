using UnityEngine;

public class Character : MonoBehaviour
{
    public float HorizontalDirection { get; private set; }

    public void SetDirection(float direction)
    {
        HorizontalDirection = direction;
    }

    public void ResetDirection()
    {
        HorizontalDirection = 0;
    }
}
