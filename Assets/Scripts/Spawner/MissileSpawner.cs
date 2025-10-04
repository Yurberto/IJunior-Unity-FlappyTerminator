public class MissileSpawner : Spawner<Missile>
{
    protected override void Awake()
    {
        if (Container == null)
            Container.SetParent(transform, true);

        base.Awake();
    }

    private void OnDisable()
    {
        ReleaseAll();    
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
