using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _waterResistance = 2000;
    
    private TuchButton _reverseDirectionButton;
    private GroundDetecter _groundDetecter;
    private bool _isMoveDirectionRight = false;
    private Rigidbody _rigidbody;


    public void Initialize(GroundDetecter groundDetecter, TuchButton button)
    {
        _reverseDirectionButton = button;
        _groundDetecter = groundDetecter;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _isMoveDirectionRight = _groundDetecter.GroundIsRight;
        _reverseDirectionButton.ButtonPressed += ReversDirection;
    }

    private void OnDisable() => _reverseDirectionButton.ButtonPressed += ReversDirection;

    private void FixedUpdate()
    {
        _speed += _acceleration;
        Vector3 position = transform.position;
        position += _isMoveDirectionRight ? Vector3.right * _speed : Vector3.forward * _speed;
        _rigidbody.MovePosition(position);
        transform.eulerAngles = _isMoveDirectionRight ? new Vector3(0, 90, 0) : new Vector3(0, 0, 0);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BuoyantForce water))
        {
            _rigidbody.AddForce(_isMoveDirectionRight ? Vector3.right * _speed * _waterResistance : Vector3.forward * _speed * _waterResistance);
            _rigidbody.drag = 1;
            _acceleration = 0;
            _speed = 0;
        }
    }
    
    private void ReversDirection() => _isMoveDirectionRight = !_isMoveDirectionRight;
}
