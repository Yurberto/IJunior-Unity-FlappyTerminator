using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private Collider2D _spawnZone;
    [SerializeField, Range(0.0f, 30.0f)] private float _spawnDelay = 4.5f;

    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    protected override void GetAction(Enemy @object)
    {
        base.GetAction(@object);
        @object.transform.position = GetRandomPosition();

        @object.Dead += Release;
    }

    protected override void ReleaseAction(Enemy @object)
    {
        base.ReleaseAction(@object);

        @object.Dead -= Release;
    }

    private Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(_spawnZone.bounds.min.x, _spawnZone.bounds.max.x);
        float randomY = Random.Range(_spawnZone.bounds.min.y, _spawnZone.bounds.max.y);

        return new Vector2(randomX, randomY);
    }

    private IEnumerator SpawnCoroutine()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }
}
