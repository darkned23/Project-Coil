using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;
    
    public Vector2 sensibility;
    public Transform player;
    public float xRotation;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * (sensibility.x * Time.deltaTime);
        _mouseY = Input.GetAxis("Mouse Y") * (sensibility.y * Time.deltaTime);

        xRotation -= _mouseY;
        xRotation = Mathf.Clamp(xRotation, 0f, 40f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * _mouseX);
    }
}