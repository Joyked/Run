using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public static PlayerMover Player;
    
    [SerializeField] private DirectionDetected _directionDetected;
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _waterResistance = 2000;

    private bool _isGroundDetectedRight = false;
    private Rigidbody _rigidbody;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _directionDetected.GroundIsOnRight += TurnToRight;
    }

    private void OnDisable()
    {
        _directionDetected.GroundIsOnRight -= TurnToRight;
    }

    private void FixedUpdate()
    {
        _speed += _acceleration;
        Vector3 position = transform.position;
        position += _isGroundDetectedRight ? Vector3.right * _speed : Vector3.forward * _speed;
        _rigidbody.MovePosition(position);
        transform.eulerAngles = _isGroundDetectedRight ? new Vector3(0, 90, 0) : new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            _isGroundDetectedRight = !_isGroundDetectedRight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BuoyantForce water))
        {
            _rigidbody.AddForce(_isGroundDetectedRight ? Vector3.right * _speed * _waterResistance : Vector3.forward * _speed * _waterResistance);
            _rigidbody.drag = 1;
            _acceleration = 0;
            _speed = 0;
        }
    }

    private void TurnToRight()
    {
        _isGroundDetectedRight = true;
    }
}
