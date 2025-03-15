using UnityEngine;

public class MoverObject : MonoBehaviour
{
    private PlayerMover _playerMover;
    
    public void Initialize(PlayerMover player) => _playerMover = player;
    
    private void Update()
    {
        transform.position = new Vector3(_playerMover.transform.position.x, transform.position.y,
            _playerMover.transform.position.z);
    }
}
