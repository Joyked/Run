using UnityEngine;

public class AudioSwipe : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceLeft;
    [SerializeField] private AudioSource _sourceRight;
    [Space]
    [SerializeField] private InputSwipeHandler _inputSwipeHandler;
    [SerializeField] private BuoyantForce _buoyantForce;

    private bool _inWater = false;

    private void OnEnable()
    {
        _inputSwipeHandler.SwipedLeft += _sourceLeft.Play;
        _inputSwipeHandler.SwipedRight += _sourceRight.Play;
    }

    private void OnDisable()
    {
        _inputSwipeHandler.SwipedLeft -= _sourceLeft.Play;
        _inputSwipeHandler.SwipedRight -= _sourceRight.Play;
    }
}
