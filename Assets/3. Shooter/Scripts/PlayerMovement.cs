using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public event EventHandler OnStartMovingAnimation;
    public event EventHandler OnStartIdleAnimation;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChekcer _groundChecker;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;

        _direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (_direction.magnitude >= 0.1f)
        {
            OnStartMovingAnimation?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnStartIdleAnimation?.Invoke(this, EventArgs.Empty);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _direction * _movementSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (_groundChecker.IsGrounded())
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
