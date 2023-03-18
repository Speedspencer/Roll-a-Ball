using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public Vector3 startingPosition = new Vector3(0f, 0.5f, 0f);

    private Rigidbody rb;
    public Transform cameraTransform;

    private void OnValidate()
    {
        transform.position = startingPosition;
    }
    
    public void Restart()
    {
        transform.position = startingPosition;
        rb.velocity = Vector3.zero;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Restart();
        cameraTransform = Camera.main.transform;
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(verticalInput, 0f, -horizontalInput);
        inputDirection = cameraTransform.TransformDirection(inputDirection);
        inputDirection.y = 0f;

        if (inputDirection.magnitude > 0.01f)
        {
            inputDirection.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.angularVelocity = inputDirection * moveSpeed;
        }
    }
}
