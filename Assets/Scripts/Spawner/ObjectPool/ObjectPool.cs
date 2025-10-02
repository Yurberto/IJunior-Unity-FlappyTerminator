using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> _queue;

    private Func<T> _create;

    public void Initialize(Func<T> create)
    {
        _create = create;
        _queue = new Queue<T>();
    }

    public T Get()
    {
        if (_queue == null)
            return null;

        if (_queue.Count == 0)
        {
            _queue.Enqueue(_create());
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
