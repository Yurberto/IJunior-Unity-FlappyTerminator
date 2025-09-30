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

    private Rigidbody2D _rigidbody2D;

    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;

        _maxRotation = Quaternion.Euler(RotationX, RotationY, _maxRotationZ);
        _minRotation = Quaternion.Euler(RotationX, RotationY, _minRotationZ);
    }

    public void Reset()
    {
        transform.position = _startPosition;
    }

    public void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _jumpForce);
        transform.rotation = _maxRotation;
    }

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}
