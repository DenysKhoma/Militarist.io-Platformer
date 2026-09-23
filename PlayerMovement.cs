using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontal;
    private float _speed = 8f;
    private float _jumpPower = 8f;
    private bool _isFacingRight = true;

    private float _coyoteTime = 0.2f;
    private float _coyoteTimeCounter;

    private float _jumpBufferTime = 0.2f;
    private float _jumpBufferCounter;

    private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jumping();
        Flip();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(_horizontal * _speed, _rigidbody.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0 || _isFacingRight == false && _horizontal > 0)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void Move()
    {
        float horizontal = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.dKey.isPressed) horizontal += 1f;
            if (Keyboard.current.aKey.isPressed) horizontal -= 1f;
        }

        _horizontal = horizontal;
    }

    private void Jumping()
    {
        if (IsGrounded()) _coyoteTimeCounter = _coyoteTime;
        else _coyoteTimeCounter -= Time.deltaTime;

        if (Keyboard.current.spaceKey.wasPressedThisFrame) _jumpBufferCounter = _jumpBufferTime;
        else _jumpBufferCounter -= Time.deltaTime;


        if (_coyoteTimeCounter > 0 && _jumpBufferCounter > 0)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpPower);
            _jumpBufferCounter = 0;
            _coyoteTimeCounter = 0;
        }

        if (Keyboard.current.spaceKey.wasReleasedThisFrame && _rigidbody.linearVelocity.y > 0)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _rigidbody.linearVelocity.y * 0.5f);
        }
    }
}
