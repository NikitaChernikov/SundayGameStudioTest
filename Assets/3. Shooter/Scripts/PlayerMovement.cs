using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public event EventHandler OnStartMoving;
    public event EventHandler OnStopMoving;
    public event EventHandler OnJumped;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;

        _direction = new Vector3(horizontalInput, 0, verticalInput);
        _direction = transform.TransformDirection(_direction).normalized;

        if (_direction.magnitude >= 0.1f)
        {
            OnStartMoving?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnStopMoving?.Invoke(this, EventArgs.Empty);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _direction * _movementSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
        OnJumped?.Invoke(this, EventArgs.Empty);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }
}
