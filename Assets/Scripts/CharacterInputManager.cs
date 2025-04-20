using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputManager : MonoBehaviour
{
    private Vector2 _inputMove = Vector2.zero;
    private Vector2 _inputLook = Vector2.zero;
    private bool _isRunning;
    public Vector2 InputMove => _inputMove;
    public Vector2 InputLook => _inputLook;
    public bool IsRunning => _isRunning;
    
    
    public void OnMove(InputAction.CallbackContext context) => _inputMove = context.ReadValue<Vector2>();
    public void OnLook(InputAction.CallbackContext context) => _inputLook = context.ReadValue<Vector2>();
    public void OnRun(InputAction.CallbackContext context) => _isRunning = context.ReadValueAsButton();
}
