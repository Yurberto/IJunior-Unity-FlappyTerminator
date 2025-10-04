public class MissileSpawner : Spawner<Missile>
{
    protected override void Awake()
    {
        if (Container == null)
            Container = transform;

        base.Awake();
    }

    public override Missile Spawn()
    {
        Missile spawnedMissile = base.Spawn();
        spawnedMissile.ReleaseTimeCome += Release;

        return spawnedMissile;
    }

    protected override void Release(Missile missileToRelease)
    {
        base.Release(missileToRelease);
        missileToRelease.ReleaseTimeCome -= Release;
    }
}
