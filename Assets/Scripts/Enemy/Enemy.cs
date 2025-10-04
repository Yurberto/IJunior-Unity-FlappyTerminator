using System;
using UnityEngine;

[RequireComponent(typeof(Obstacle))]
[RequireComponent(typeof(EnemyShooter))]
[RequireComponent(typeof(EnemyTriggerHandler))]
public class Enemy : MonoBehaviour
{
    private EnemyShooter _enemyShooter;
    private EnemyTriggerHandler _triggerHandler;

    public event Action Dead;
    public event Action<Enemy> ReleaseTimeCome;

    public void Initialize(MissileSpawner missileSpawner)
    {
        _enemyShooter.Initialize(missileSpawner);
    }

    private void Awake()
    {
        _enemyShooter = GetComponent<EnemyShooter>();
        _triggerHandler = GetComponent<EnemyTriggerHandler>();
    }

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnEnable()
    {
        _triggerHandler.PlayerMissileHitted += Die;
        _triggerHandler.ReleaseZoneHitted += Release;
    }

    private void OnDisable()
    {
        _triggerHandler.PlayerMissileHitted -= Die;
        _triggerHandler.ReleaseZoneHitted -= Release;
    }

    public void StartShooting()
    {
        _enemyShooter.StartShooting();
    }

    private void Die()
    {
        Dead?.Invoke();
        Release();
    }

    private void Release()
    {
        ReleaseTimeCome?.Invoke(this);
    }
}
