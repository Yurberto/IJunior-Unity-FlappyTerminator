public class MissileSpawner : Spawner<Missile>
{
    protected override void GetAction(Missile @object)
    {
        base.GetAction(@object);
        @object.ReleaseTimeCome += Release;
    }

    protected override void ReleaseAction(Missile @object)
    {
        base.ReleaseAction(@object);
        @object.ReleaseTimeCome -= Release;
    }
}
