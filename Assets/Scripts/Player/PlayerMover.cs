using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float RotationX = 0.0f;
    private const float RotationY = 0.0f;

    [SerializeField, Range(0.0f, 10.0f)] private float _speed = 2.5f;
    [SerializeField, Range(0.0f, 10.0f)] private float _jumpForce = 3.0f;

    [SerializeField, Range(0.0f, 10.0f)] private float _rotationSpeed = 3.0f;
    [SerializeField, Range(0.0f, 180.0f)] private float _maxRotationZ = 35.0f;
    [SerializeField, Range(-180.0f, 0.0f)] private float _minRotationZ = -55.0f;

    private bool _isRotateUp;

    private Rigidbody2D _rigidbody2D;

    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Quaternion _targetRotation;

    private Coroutine _rotateToUp;

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.angularVelocity = 0.0f;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _isRotateUp = false;

        _maxRotation = Quaternion.Euler(RotationX, RotationY, _maxRotationZ);
        _minRotation = Quaternion.Euler(RotationX, RotationY, _minRotationZ);
    }

    private void Update()
    {
        if (_isRotateUp)
            _targetRotation = _maxRotation;
        else 
            _targetRotation = _minRotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _jumpForce);
        StartRotatateToUpCoroutine();
    }

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
    }

    private void StartRotatateToUpCoroutine()
    {
        if (_rotateToUp != null)
        {
            StopCoroutine(_rotateToUp);
            _rotateToUp = null;
        }

        _rotateToUp = StartCoroutine(RotateToUp());
    }

    private IEnumerator RotateToUp()
    {
        _isRotateUp = true;
        yield return new WaitWhile(() => _rigidbody2D.velocity.y > 0);
        _isRotateUp = false;
    }
}
