using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField, Range(0.0f, 200.0f)] float _missileSpeed = 5.0f;
    [SerializeField] Vector2 _spawnOffset;

    private MissileSpawner _missileSpawner;

    private Vector3 _spawnOffset3D;

    private void Awake()
    {
        _missileSpawner = GetComponent<MissileSpawner>();

        _spawnOffset3D = new Vector3(_spawnOffset.x, _spawnOffset.y, 0.0f);
    }

    public void Shoot(Vector2 direction)
    {
        Missile spawnedMissile = _missileSpawner.Spawn();

        spawnedMissile.transform.position = transform.position + _spawnOffset3D;
        spawnedMissile.Rigidbody2D.velocity = direction * _missileSpeed;
    }
}
