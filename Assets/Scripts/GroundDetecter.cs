using UnityEngine;

public class GroundDetecter : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
            _counter.AddPoint();
    }
}
