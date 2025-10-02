using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Transform _parent;
    private T _prefab;
    private Queue<T> _queue;

    public IEnumerable<T> PoolObjects => _queue;

    public void Initialize(T prefab, Transform parent)
    {
        _parent = parent;
        _prefab = prefab;
        _queue = new Queue<T>();
    }

    public T Get()
    {
        if (_prefab == null || _queue == null)
            return null;

        if (_queue.Count == 0)
        {
            Instantiate(_prefab, _parent);
        }

        T spawnedObject = _queue.Dequeue();
        spawnedObject.gameObject.SetActive(true);

        return spawnedObject;
    }

    public void Release(T objectToRelease)
    {
        _queue.Enqueue(objectToRelease);
        objectToRelease.gameObject.SetActive(false);
    }
}
