public class MissileSpawner : Spawner<Missile>
{
    protected override void Awake()
    {
        Pool = GetComponent<ObjectPool<Missile>>();

        if (Container == null)
            Pool.Initialize(Prefab, transform);
        else
            Pool.Initialize(Prefab, Container);
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
