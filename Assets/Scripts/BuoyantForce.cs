using System;
using UnityEngine;

public class BuoyantForce : MonoBehaviour
{
    public event Action InWater; 
    
    [SerializeField] float _waterDensity = 10f;
    
    private Rigidbody _rigidbody;
    private float _surface;
    private float _divePercent;
    private float _percentWater;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {
            _rigidbody = player.GetComponent<Rigidbody>();
            _surface = player.transform.position.y;
            _percentWater = (_surface - transform.position.y) / 100;
            InWater?.Invoke();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
            _rigidbody = null;
    }

    private void FixedUpdate()
    {
        if (_rigidbody != null)
        {
            _divePercent = (_surface - _rigidbody.transform.position.y) / _percentWater;
            _rigidbody.AddForce(Vector3.up * _waterDensity * _divePercent * Time.deltaTime);
        }
    }
}
