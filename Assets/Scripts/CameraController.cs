using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 1f;
    public float minAngle = -0f;
    public float maxAngle = 50f;

    private float mouseX, mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = FindAnyObjectByType<PlayerController>().transform;
    }
    
    private void OnValidate()
    {
        if (player == null) return;
        transform.position = player.position + offset;
    }

    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, minAngle, maxAngle);

        Quaternion rotation = Quaternion.Euler(-mouseY, mouseX, 0f);
        var position = player.position;
        Vector3 desiredPosition = position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(position);
    }
}
