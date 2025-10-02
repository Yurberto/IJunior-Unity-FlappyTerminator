using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private Transform _container;
    [SerializeField] private Collider2D _spawnZone;
    [SerializeField, Range(0.0f, 30.0f)] private float _spawnDelay = 4.5f;

    private Coroutine _spawnCoroutine;

    public event Action EnemyDead;

    public void StopSpawn()
    {
        StopCoroutine(SpawnCoroutine());
        _spawnCoroutine = null;
    }

    public void StartSpawn()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(SpawnCoroutine());
            _spawnCoroutine = null;
        }

        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    public override Enemy Spawn()
    {
        Enemy spawnedEnemy = base.Spawn();
        spawnedEnemy.transform.position = GetRandomPosition();

        spawnedEnemy.Dead += InvokeEnemyDead;
        spawnedEnemy.ReleaseTimeCome += Release;

        return spawnedEnemy;
    }

    protected override void Release(Enemy @object)
    {
        base.Release(@object);

        @object.Dead -= InvokeEnemyDead;
        @object.ReleaseTimeCome -= Release;
    }

    private IEnumerator SpawnCoroutine()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            Enemy spawnedEnemy = Spawn();
            spawnedEnemy.StartShooting();

            yield return wait;
        }
    }

    private Vector2 GetRandomPosition()
    {
        float randomY = Random.Range(_spawnZone.bounds.min.y, _spawnZone.bounds.max.y);

        return new Vector2(_spawnZone.bounds.min.x, randomY);
    }

    private void InvokeEnemyDead()
    {
        EnemyDead?.Invoke();
    }
}
