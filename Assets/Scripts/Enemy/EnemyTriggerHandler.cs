using System;
using UnityEngine;

public class EnemyTriggerHandler : MonoBehaviour
{
    public event Action MissileHitted;
    public event Action ReleaseZoneHitted;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Missile _))
            MissileHitted?.Invoke();

        if (other.TryGetComponent(out ReleaseZone _))
            ReleaseZoneHitted?.Invoke();
    }
}
