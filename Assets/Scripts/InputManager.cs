using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Vector2 _moveInput = Vector3.zero;
    private Vector2 _lookInput = Vector3.zero;
    private bool _jumpInput;

    public Vector2 MoveInput => _moveInput;
    public Vector2 LookInput => _lookInput;
    public bool JumpInput => _jumpInput;

    public void OnMove(InputAction.CallbackContext context) => _moveInput = context.ReadValue<Vector2>();
    public void OnLook(InputAction.CallbackContext context) => _lookInput = context.ReadValue<Vector2>();
    public void OnJump(InputAction.CallbackContext context) => _jumpInput = context.ReadValueAsButton();
}
