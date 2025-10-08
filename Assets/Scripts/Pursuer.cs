using UnityEngine;

public class Pursuer : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        if (_target.transform.position.x >= transform.position.x || _target.transform.position.z >= transform.position.z)
            transform.position = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);
        
    }
}
