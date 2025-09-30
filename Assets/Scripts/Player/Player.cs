using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(CollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;

    private PlayerMover _playerMover;
    private CollisionHandler _collisionHandler;

    public event Action Dead;

    public void Reset()
    {
        _playerMover.Reset();
    }

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _inputReader.JumpKeyPressed += Jump;
        _collisionHandler.ObstacleHitted += Die;
    }

    private void OnDisable()
    {
        _inputReader.JumpKeyPressed -= Jump;
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

    private void Die()
    {
        Dead?.Invoke();
    }
}
