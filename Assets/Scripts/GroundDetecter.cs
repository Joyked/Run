using UnityEngine;

public class GroundDetecter : MonoBehaviour
{
    public bool GroundIsRight { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ground ground))
            GroundIsRight = true;
    }
}
