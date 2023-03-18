using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    public float fallSpeed = 10f;
    public float riseSpeed = 2f;
    public float fallDelay = 0f;
    public float riseDelay = 1f;
    public float maxFallDistance = 10f;

    private bool isFalling = false;
    private bool isRising = false;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Invoke("StartFalling", fallDelay);
        }
    }

    private void StartFalling()
    {
        isFalling = true;
        Invoke("StartRising", riseDelay);
    }

    private void Update()
    {
        if (isFalling)
        {
            float fallStep = fallSpeed * Time.deltaTime;
            Vector3 newPos = transform.position + Vector3.down * fallStep;
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * fallSpeed);
            isRising = false;
            
        }
        else if (isRising)
        {
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * riseSpeed);

            if (transform.position.y >= startPos.y)
            {
                transform.position = startPos;
                isRising = false;
            }
        }
    }

    private void StartRising()
    {
        isFalling = false;
        isRising = true;
    }
}
