using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody _rb;
    private Vector3 _move;
    public float speed;
    public float jump;
    public Transform orientation;
    public LayerMask ground;
    
    private float _vertical;
    private float _horizontal;

    public float downwardForce;
    public float downwardMultiplier;
    
    private InputManager _input;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        _horizontal = _input.MoveInput.x;
        _vertical = _input.MoveInput.y;
        
        _move = orientation.right * _horizontal + orientation.forward * _vertical;

        if (_input.JumpInput && IsGrounded())
        {
            Jumping();
        }

        if (IsGrounded())
        {
            downwardForce = 0;
        }
        else
        {
            downwardForce += Time.deltaTime * downwardMultiplier;
            _rb.AddForce(-transform.up * downwardForce, ForceMode.Acceleration);
        }
    }

    void FixedUpdate()
    {
       _rb.AddForce(_move.normalized * speed, ForceMode.Acceleration);
    }

    public void Jumping()
    {
        _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z);
        _rb.AddForce(transform.up * jump, ForceMode.Impulse);
    }

    public bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f, ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
        
}
