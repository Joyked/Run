using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static event Action<Ground> EnterInSpawn;
    public static event Action <Ground> ExitInSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Spawner spawner))
        {
            EnterInSpawn?.Invoke(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Spawner spawner))
            ExitInSpawn?.Invoke(this);
    }
}
