using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected Transform Container;

    protected ObjectPool<T> Pool;

    protected virtual void Awake()
    {
        Pool = GetComponent<ObjectPool<T>>();
        Pool.Initialize(() => Instantiate(Prefab, Container));
    }

    public virtual void ReleaseAll()
    {
        for (int i = 0; i < Container.childCount; i++)
            if (Container.GetChild(i).TryGetComponent(out T objectToRelease))
                Release(objectToRelease);
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
