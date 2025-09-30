using UnityEngine;
using UnityEngine.Pool;

public class Generator<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>
            (
                createFunc: () => Instantiate(_prefab, _container),
                actionOnGet: (@object) => GetAction(@object),
                
            );
    }

    private void GetAction(T @object)
    {

    }
}
