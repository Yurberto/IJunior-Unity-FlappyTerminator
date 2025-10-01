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

    private Coroutine _shootCoroutine = null;

    public event Action<Enemy> Dead;

    private void Awake()
    {
        Debug.Log("Enemy Awake");

        _shooter = GetComponent<Shooter>();

        _triggerHandler = GetComponent<EnemyTriggerHandler>();
    }

    private void Start()
    {
        Debug.Log("ENEMY START");

        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnEnable()
    {
        Debug.Log("Enemy ONENable");

        _triggerHandler.MissileHitted += Die;
        _triggerHandler.ReleaseZoneHitted += Die;

        Debug.Log("START Shooting");

        StartShooting();
    }

    private void OnDisable()
    {
        _triggerHandler.MissileHitted -= Die;
        _triggerHandler.ReleaseZoneHitted -= Die;
    }

    private void Shoot()
    {
        if (_shooter == null)
        {
            Debug.LogError("SHOOTERA HET");
            return;
        }
        _shooter.Shoot(-transform.right);
    }

    private void StartShooting()
    {
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }

        _shootCoroutine = StartCoroutine(ShootCoroutine());
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
