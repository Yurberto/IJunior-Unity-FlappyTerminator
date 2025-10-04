using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool<T> where T : MonoBehaviour
{
    private Queue<T> _queue;
    private Func<T> _create;

    public ObjectsPool(Func<T> create)
    {
        _queue = new Queue<T>();
        _create = create;
    }

    public T Get()
    {
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
        if (objectToRelease == null)
            return;

        _queue.Enqueue(objectToRelease);
        objectToRelease.gameObject.SetActive(false);
    }
}
