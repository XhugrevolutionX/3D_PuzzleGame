using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Transform _rootCharacter;
    
    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 8f;
    
    private CharacterInputManager _inputs;
    private Animator _animator;
    
    
    private float _angleVelocity;
    private float _speedVelocity;
    private float _strafeVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputs = GetComponent<CharacterInputManager>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputs.InputMove.magnitude >= Mathf.Epsilon)
        {
           
            // Not aiming : Rotation
            float targetAngle = Camera.main.transform.rotation.eulerAngles.y;
            targetAngle += Mathf.Atan2(_inputs.InputMove.x, _inputs.InputMove.y) * Mathf.Rad2Deg;

            float actualAngle = Mathf.SmoothDampAngle(_rootCharacter.eulerAngles.y, targetAngle, ref _angleVelocity, 0.25f);

            _rootCharacter.rotation = Quaternion.Euler(0, actualAngle, 0);

            float horizontalSpeed = _inputs.IsRunning ? _runSpeed : _walkSpeed;
            _animator.SetFloat("Speed", Mathf.SmoothDamp(_animator.GetFloat("Speed"), _inputs.InputMove.magnitude * horizontalSpeed, ref _speedVelocity, 0.25f));
      
        }
        else
        {
            _animator.SetFloat("Speed", Mathf.SmoothDamp(_animator.GetFloat("Speed"), 0f, ref _speedVelocity, 0.025f));
        }
    }
}
