using UnityEngine;

public static class LayerMaskData 
{
    public static readonly LayerMask PlayerMissile = LayerMask.GetMask(nameof(PlayerMissile));
    public static readonly LayerMask EnemyMissile = LayerMask.GetMask(nameof(EnemyMissile));
}
