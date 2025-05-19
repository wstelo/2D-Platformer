using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public event Action EnterButtonClicked;

    public float Horizontal { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxis(nameof(Horizontal));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnterButtonClicked?.Invoke();
        }
    }
}
