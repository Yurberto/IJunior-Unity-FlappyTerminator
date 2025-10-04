using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private Collider2D _spawnZone;
    [SerializeField, Range(0.0f, 30.0f)] private float _spawnDelay = 4.5f;
    [SerializeField] private MissileSpawner _enemyMissileSpawner;

    private Coroutine _spawnCoroutine;

    public event Action EnemyDead;

    private void Start()
    {
        StartSpawn();   
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
        spawnedEnemy.Initialize(_enemyMissileSpawner);
        spawnedEnemy.transform.position = GetRandomPosition();

        spawnedEnemy.ReleaseTimeCome += Release;
        spawnedEnemy.Dead += InvokeEnemyDead;

        return spawnedEnemy;
    }

    protected override void Release(Enemy enemyToRelease)
    {
        base.Release(enemyToRelease);

        enemyToRelease.ReleaseTimeCome -= Release;
        enemyToRelease.Dead -= InvokeEnemyDead;
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
