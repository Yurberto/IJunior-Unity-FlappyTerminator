using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;

    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _inputReader.JumpKeyPressed += Jump;
    }

    private void OnDisable()
    {
        _inputReader.JumpKeyPressed -= Jump;
    }

    private void FixedUpdate()
    {
        _playerMover.Move();
    }

    private void Jump()
    {
        _playerMover.Jump();
    }
}
