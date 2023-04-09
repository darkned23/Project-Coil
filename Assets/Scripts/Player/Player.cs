using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speedMove = 7f;
        [SerializeField] private Transform mainCamera;
    
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private float groundDistance = 0.3f;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundMask;
    
        [SerializeField] private float turnSmoothTime = 1.2f;
        private float _turnSmoothVelocity;
        private CharacterController _characterController;
    
        private Vector3 _velocity;
        private bool _isGrounded;
    
        private Vector2 _mouseInput;
        private float _xRot; 
        [SerializeField] private float sensitivityCamera = 1f;
        [SerializeField] private float minVerticalAngle = -80f;
        [SerializeField] private float maxVerticalAngle = 80f;
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        private void Update()
        {
            _mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            Jump();
            Move();
            MoveCamera();
        }
        private void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
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
        private void MoveCamera()
        {
            _xRot -= _mouseInput.y * sensitivityCamera;
            _xRot = Mathf.Clamp(_xRot, minVerticalAngle, maxVerticalAngle);
            transform.Rotate(0f, _mouseInput.x * sensitivityCamera, 0f);
            mainCamera.transform.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
        }
    }
}