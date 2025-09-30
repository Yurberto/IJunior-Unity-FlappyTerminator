using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;

    private ObjectPool<T> _pool;

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>
            (
                createFunc: () => Instantiate(_prefab, _container),
                actionOnGet: (@object) => GetAction(@object),
                actionOnRelease: (@object) => ReleaseAction(@object),
                actionOnDestroy: (@object) => Destroy(@object.gameObject),
                collectionCheck: true
            );
    }

    public T Spawn()
    {
        return _pool.Get();
    }

    protected void Release(T @object)
    {
        _pool.Release(@object);
    }

    protected virtual void GetAction(T @object)
    {
        @object.gameObject.SetActive(true);
    }

    protected virtual void ReleaseAction(T @object)
    {
        @object.gameObject.SetActive (false);
    }
}
