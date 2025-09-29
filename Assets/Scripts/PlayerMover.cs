using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputSwipeHandler _swipeHandler;
    [SerializeField] private BuoyantForce _water;
    [Space]
    [Header("Params")]
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _velocity;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private bool _isStarted = false;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _swipeHandler.SwipedLeft += TurnLeft;
        _swipeHandler.SwipedRight += TurnRight;
        _water.InWater += Stop;
    }

    private void OnDisable()
    {
        _swipeHandler.SwipedLeft -= TurnLeft;
        _swipeHandler.SwipedRight -= TurnRight;
        _water.InWater -= Stop;
    }

    private void FixedUpdate()
    {
        if (_isStarted)
        {
            Vector3 newPosition = (transform.position + _direction * _startSpeed);
            _rigidbody.MovePosition(newPosition);
            _startSpeed += _velocity;
        }
    }

    private void TurnLeft()
    {
        _direction = Vector3.forward;

        if (_isStarted == false)
            _isStarted = true;
    }

    private void TurnRight()
    {
        _direction = Vector3.right;
        
        if (_isStarted == false)
            _isStarted = true;
    }

    private void Stop()
    {
        _startSpeed = 0;
        _velocity = 0;
        _direction = Vector3.zero;
    }
}




