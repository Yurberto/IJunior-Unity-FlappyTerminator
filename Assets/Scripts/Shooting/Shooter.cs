using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField, Range(0.0f, 200.0f)] private float _missileSpeed = 5.0f;
    [SerializeField] private Vector2 _spawnOffset;

    private MissileSpawner _missileSpawner;

    private Vector3 _spawnOffset3D;

    public void Initialize(MissileSpawner missileSpawner)
    {
        _missileSpawner = missileSpawner;
    }

    private void Awake()
    {
        _spawnOffset3D = new Vector3(_spawnOffset.x, _spawnOffset.y, 0.0f);
    }

    public void Shoot(Vector2 direction)
    {
        if (_missileSpawner == null) 
            return;

        Missile spawnedMissile = _missileSpawner.Spawn();

        spawnedMissile.transform.position = transform.position + _spawnOffset3D;
        spawnedMissile.Rigidbody2D.velocity = direction * _missileSpeed;
    }
}
