using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected Transform Container;

    protected ObjectsPool<T> Pool;

    protected virtual void Awake()
    {
        Pool = new ObjectsPool<T>(() => Instantiate(Prefab, Container));
    }

    public void ReleaseAll()
    {
        if (Container == null)
            return;

        for (int i = 0; i < Container.childCount; i++)
            if (Container.GetChild(i).TryGetComponent(out T objectToRelease))
                Release(objectToRelease);
    }

    public virtual T Spawn()
    {
        return Pool.Get();
    }

    protected virtual void Release(T objectToRelease)
    {
        Pool.Release(objectToRelease);
    }
}
