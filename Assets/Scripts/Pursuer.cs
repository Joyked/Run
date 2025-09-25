using UnityEngine;

public class Pursuer : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x, transform.position.y,
            _target.transform.position.z);
    }
}
