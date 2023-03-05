using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    
    public Vector2 sensibility;
    public Transform player;
    public float xRotation =  0;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * (sensibility.x * Time.deltaTime);
        mouseY = Input.GetAxis("Mouse Y") * (sensibility.y * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        player.Rotate(Vector3.up * mouseX);
    }
}