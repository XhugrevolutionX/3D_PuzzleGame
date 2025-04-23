using UnityEngine;
using UnityEngine.InputSystem;

public class CamMovement : MonoBehaviour
{ 
    [SerializeField] private GameObject player;
    
    private PlayerInput _playerInput;
    private InputManager _inputs; 

    
    public float mouseSens;
    
    public float gamepadSens;
    
    public Transform orientation;

    private float _xRotation;
    private float _yRotation;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        _playerInput = player.GetComponent<PlayerInput>();
        _inputs = player.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;
        
        if (_playerInput.currentControlScheme == "Keyboard&Mouse")
        {
            mouseX = _inputs.LookInput.x * Time.deltaTime * mouseSens;
            mouseY = _inputs.LookInput.y * Time.deltaTime * mouseSens;
        }
        else if (_playerInput.currentControlScheme == "Gamepad")
        {
            mouseX = _inputs.LookInput.x * Time.deltaTime * gamepadSens;
            mouseY = _inputs.LookInput.y * Time.deltaTime * gamepadSens;
        }
        
        _yRotation += mouseX;
        _xRotation -= mouseY;
        
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        
        orientation.rotation = Quaternion.Euler(0f, _yRotation, 0f);
        
        player.transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }
}
