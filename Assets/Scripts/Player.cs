using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 200f, forceMove = 100f;
    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private Vector2 input;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        input = _playerInput.actions["Move"].ReadValue<Vector2>();
        //rotacion camara
        float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(input.x, 0f, input.y) * forceMove);
    }
    //Metodo para saltar
    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce);
            Debug.Log("Jumping...");
        }
    }
}