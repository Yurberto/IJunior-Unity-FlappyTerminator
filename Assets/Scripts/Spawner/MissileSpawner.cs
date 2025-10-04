public class MissileSpawner : Spawner<Missile>
{
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
