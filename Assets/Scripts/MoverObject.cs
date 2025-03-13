using UnityEngine;

public class MoverObject : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    private void Update()
    {
        transform.position = new Vector3(_playerMover.transform.position.x, transform.position.y,
            _playerMover.transform.position.z);
    }
}
