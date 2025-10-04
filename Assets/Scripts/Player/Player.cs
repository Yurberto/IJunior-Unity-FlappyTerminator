using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(PlayerTriggerHandler))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private MissileSpawner _missileSpawner;

    private PlayerMover _playerMover;
    private Shooter _shooter;
    private PlayerTriggerHandler _collisionHandler;

    public event Action Dead;

    public void Reset()
    {
        _playerMover.Reset();
    }

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _shooter = GetComponent<Shooter>();
        _collisionHandler = GetComponent<PlayerTriggerHandler>();

        _shooter.Initialize(_missileSpawner);
    }

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnEnable()
    {
        _inputReader.JumpKeyPressed += Jump;
        _inputReader.ShootKeyPressed += Shoot;
        _collisionHandler.ObstacleHitted += Die;
    }

    private void OnDisable()
    {
        _inputReader.JumpKeyPressed -= Jump;
        _inputReader.ShootKeyPressed -= Shoot;
        _collisionHandler.ObstacleHitted -= Die;
    }

    private void FixedUpdate()
    {
        _playerMover.Move();
    }

    private void Jump()
    {
        _playerMover.Jump();
    }

    private void Shoot()
    {
        _shooter.Shoot(transform.right);
    }

    private void Die()
    {
        Dead?.Invoke(); 
    }
}
