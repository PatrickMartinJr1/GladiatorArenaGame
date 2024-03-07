using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Unit : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private float _horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float _jumpingPower = 16f;
    private bool _isFacingRight = true;

    [SerializeField] private GameObject _attackArea;
    [SerializeField] private AudioSource _meleeSound;

    private void Update()
    {
        _rb.velocity = new Vector2(_horizontal * speed, _rb.velocity.y);

        if (!_isFacingRight && _horizontal > 0f)
        {
            Flip();
        }
        else if (_isFacingRight && _horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
        }

        if (context.canceled && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _horizontal = context.ReadValue<Vector2>().x;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayAttackSFX();
            _attackArea.SetActive(true);
            Debug.Log("attacked");

        }

        if (context.canceled)
        {
            _attackArea.SetActive(false);
            Debug.Log("stopped attacking");
        }
    }

    void PlayAttackSFX()
    {

        // play sfx
        if (_meleeSound != null)
        {
            AudioSource newSound = Instantiate(_meleeSound,
                transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }
    }
}

