using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpButton = KeyCode.Space;

    public event Action JumpButtonClicked;

    public float Horizontal { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxis(HorizontalAxis);

        if (Input.GetKeyDown(JumpButton))
        {
            JumpButtonClicked?.Invoke();
        }
    }
}
