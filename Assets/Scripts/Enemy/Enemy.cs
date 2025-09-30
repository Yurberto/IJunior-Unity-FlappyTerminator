using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Obstacle))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(EnemyTriggerHandler))]
public class Enemy : MonoBehaviour
{
    [SerializeField, Range(0.00f, 100.0f)] private float _shootDelay = 1;

    private Shooter _shooter;
    private EnemyTriggerHandler _triggerHandler;

    private Coroutine _shootCoroutine;

    public event Action<Enemy> Dead;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _triggerHandler = GetComponent<EnemyTriggerHandler>();
    }

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;

        _shootCoroutine = StartCoroutine(ShootCoroutine());
    }

    private void OnEnable()
    {
        _triggerHandler.MissileHitted += Die;
        _triggerHandler.ReleaseZoneHitted += Die;
    }

    private void OnDisable()
    {
        _triggerHandler.MissileHitted -= Die;
        _triggerHandler.ReleaseZoneHitted -= Die;
    }

    private void Shoot()
    {
        _shooter.Shoot(-transform.right);
    }

    private IEnumerator ShootCoroutine()
    {
        var wait = new WaitForSeconds(_shootDelay);

        while (enabled)
        {
            Shoot();
            yield return wait;
        }
    }

    private void Die()
    {
        Dead?.Invoke(this);
    }
}
