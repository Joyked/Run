using System;
using UnityEngine;

public class DirectionDetected : MonoBehaviour
{
    public event Action GroundIsOnRight;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Ground ground))
            GroundIsOnRight?.Invoke();
    }
}
