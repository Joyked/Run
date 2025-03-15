using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> CountUpdated;
    public int Count { get; private set; } = -1;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Ground ground))
            UpdateCount();
    }

    private void UpdateCount()
    {
        Count++;
        CountUpdated?.Invoke(Count);
    }
}
