using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public event Action<Item> Triggered;

    public void DisableObject()
    {
        Triggered?.Invoke(this);
    }
}
