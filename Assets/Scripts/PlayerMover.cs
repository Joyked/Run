using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputSwipeRider _swipeRider;
    [SerializeField] private BuoyantForce _water;
    [Space]
    [Header("Params")]
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _velocity;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _swipeRider.SwipedLeft += TurnLeft;
        _swipeRider.SwipedRight += TurnRight;
        _water.InWater += Stop;
    }

    private void OnDisable()
    {
        _swipeRider.SwipedLeft -= TurnLeft;
        _swipeRider.SwipedRight -= TurnRight;
        _water.InWater -= Stop;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = (transform.position + _direction * _startSpeed);
        _rigidbody.MovePosition(newPosition);
        _startSpeed += _velocity;
    }

    private void TurnLeft() =>
        _direction = Vector3.forward;

    private void TurnRight() =>
        _direction = Vector3.right;

    private void Stop()
    {
        _startSpeed = 0;
        _velocity = 0;
        _direction = Vector3.zero;
    }
}




