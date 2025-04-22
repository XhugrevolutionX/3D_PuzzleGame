using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private Transform orientation;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float groundDetectionRadius;
    
    [SerializeField] private float gravityForce;
    private float _downwardForce;
    
    private float _verticalMovement;
    private float _horizontalMovement;

    private Rigidbody _rb;
    private Vector3 _move;
    
    private InputManager _input;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputManager>();
        _animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = _input.MoveInput.x;
        _verticalMovement = _input.MoveInput.y;
        
        _move = orientation.right * _horizontalMovement + orientation.forward * _verticalMovement;

        if (_input.JumpInput && IsGrounded())
        {
            Jumping();
        }

        if (IsGrounded())
        {
            _downwardForce = 0;
        }
        else
        {
            _downwardForce = gravityForce;
        }
        
        _animator.SetFloat("Speed", Mathf.Abs(new Vector2(_rb.linearVelocity.x, _rb.linearVelocity.z).magnitude));
    }

    void FixedUpdate()
    {
       _rb.AddForce(_move.normalized * speed, ForceMode.Acceleration);
       _rb.AddForce(-transform.up * _downwardForce, ForceMode.Acceleration);
    }

    private void Jumping()
    {
        _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z);
        _rb.AddForce(transform.up * jump, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundDetectionRadius, ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
        
}
