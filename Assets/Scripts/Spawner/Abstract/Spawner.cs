using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected Transform Container;

    protected ObjectPool<T> Pool;

    protected virtual void Awake()
    {
        Pool = GetComponent<ObjectPool<T>>();
        Pool.Initialize(Prefab, Container);
    }

    public virtual void ReleaseAll()
    {
        IEnumerable<T> objectsToRelease = new IEnumerable<T>();
    }

    public virtual T Spawn()
    {
        return Pool.Get();
    }

    protected virtual void Release(T @object)
    {
        Pool.Release(@object);
    }
}
