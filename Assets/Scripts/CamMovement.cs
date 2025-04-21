using UnityEngine;
using UnityEngine.InputSystem;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private InputManager inputs;
    [SerializeField] private PlayerInput playerInput;
    
    public float mouseSensY;
    public float mouseSensX;
    
    public float gamepadSensY;
    public float gameSensX;

    public Transform orientation;

    private float _xRotation;
    private float _yRotation;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;
        
        if (playerInput.currentControlScheme == "Keyboard&Mouse")
        {
            mouseX = inputs.LookInput.x * Time.deltaTime * mouseSensX;
            mouseY = inputs.LookInput.y * Time.deltaTime * mouseSensY;
        }
        else if (playerInput.currentControlScheme == "Gamepad")
        {
            mouseX = inputs.LookInput.x * Time.deltaTime * gameSensX;
            mouseY = inputs.LookInput.y * Time.deltaTime * gamepadSensY;
        }
        
        _yRotation += mouseX;
        _xRotation -= mouseY;
        
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        
        orientation.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }
}
