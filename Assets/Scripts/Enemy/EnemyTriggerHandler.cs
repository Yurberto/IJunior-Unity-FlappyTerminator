using System;
using UnityEngine;

public class EnemyTriggerHandler : MonoBehaviour
{
    public event Action PlayerMissileHitted;
    public event Action ReleaseZoneHitted;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMissile _))
        {
            PlayerMissileHitted?.Invoke();
        }

        if (other.TryGetComponent(out ReleaseZone _))
            ReleaseZoneHitted?.Invoke();
    }
}
