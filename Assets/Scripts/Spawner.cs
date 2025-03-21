using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<Ground> _pool;
    private Ground _prefabGround;

    public void Initialized(Ground ground) => _prefabGround = ground;
    
    private enum Direction
    {
        Right,
        Left
    }
    
    private void Awake()
    {
        _pool = new ObjectPool<Ground>
        (
            CreateGround,
            ActionOnGet,
            ActionOnRelease,
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }
    
    private void SpawnGround(Ground ground)
    {
        Direction randomDirection = (Direction)Random.Range((int)Direction.Right, (int)Direction.Left + 1);
        Vector3 newPositiom = ground.transform.position;
        
        switch (randomDirection)
        {
            case Direction.Right:
                newPositiom += Vector3.right;
                break;
                
            case Direction.Left:
                newPositiom += Vector3.forward;
                break;
        }
        
        _pool.Get().transform.position = newPositiom;
    }

    private Ground CreateGround() => Instantiate(_prefabGround);
    
    private void DispawnGround(Ground ground) => _pool.Release(ground);
    
    private void ActionOnGet(Ground ground) => ground.gameObject.SetActive(true);

    private void ActionOnRelease(Ground ground) => ground.gameObject.SetActive(false);
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ground ground))
            SpawnGround(ground);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Ground ground))
            DispawnGround(ground);
    }
}
