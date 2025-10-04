using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField, Range(0.0f, 200.0f)] private float _missileSpeed = 5.0f;
    [SerializeField] private Transform _spawnpoint;

    private MissileSpawner _missileSpawner;

    public void Initialize(MissileSpawner missileSpawner)
    {
        _missileSpawner = missileSpawner;
    }

    public void Shoot(Vector2 direction)
    {
        if (_missileSpawner == null) 
            return;

        Missile spawnedMissile = _missileSpawner.Spawn();

        spawnedMissile.transform.position = _spawnpoint.position;
        spawnedMissile.Rigidbody2D.velocity = direction * _missileSpeed;
    }
}
