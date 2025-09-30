using System;
using UnityEngine;

[RequireComponent(typeof(Obstacle))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour
{
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;

    public event Action<Missile> ReleaseTimeCome;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ReleaseZone _))
            ReleaseTimeCome?.Invoke(this);
    }
}
