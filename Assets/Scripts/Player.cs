using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedMove = 10f;
    [SerializeField] private Transform cam;
    
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    
    private CharacterController _characterController;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    
    private Vector3 _velocity;
    private bool _isGrounded;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        Jump();
        Move();
    }
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            _characterController.Move(moveDir * (speedMove * Time.deltaTime));
        }
    }

    private void Jump()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y -= 2f;
        }
        
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }
        
        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
}