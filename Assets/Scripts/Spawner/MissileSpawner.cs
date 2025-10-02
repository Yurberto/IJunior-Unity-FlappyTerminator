using UnityEngine;

public class MissileSpawner : Spawner<Missile>
{
    protected override void Awake()
    {
        Pool = GetComponent<ObjectPool<Missile>>();

        Transform parent = (Container == null) ? transform : Container;

        Pool.Initialize(() => Instantiate(Prefab, parent));
    }

    public override Missile Spawn()
    {
        Missile spawnedMissile = base.Spawn();
        spawnedMissile.ReleaseTimeCome += Release;

        return spawnedMissile;
    }

    protected override void Release(Missile objectToRelease)
    {
        base.Release(objectToRelease);
        objectToRelease.ReleaseTimeCome -= Release;
    }
}
