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

    protected override void GetAction(Enemy @object)
    {
        base.GetAction(@object);
        @object.transform.position = GetRandomPosition();

        @object.Dead += InvokeEnemyDead;
        @object.ReleaseTimeCome += Release;
    }

    protected override void ReleaseAction(Enemy @object)
    {
        base.ReleaseAction(@object);

        @object.Dead -= InvokeEnemyDead;
        @object.ReleaseTimeCome -= Release;
    }

    protected override Enemy Create()
    {
        Enemy spawnedEnemy = base.Create();
        spawnedEnemy.transform.parent = _container;

        return spawnedEnemy;
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
