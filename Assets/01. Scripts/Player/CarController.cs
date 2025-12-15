using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Speed")]
    public float maxForwardSpeed = 15f;
    public float maxReverseSpeed = 5f;
    public float acceleration = 20f;
    public float brakeDeceleration = 30f;
    public float friction = 10f;

    [Header("Turning")]
    public float turnSpeed = 120f;

    float currentSpeed = 0f;

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float turnInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            turnInput = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            turnInput = 1f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currentSpeed -= brakeDeceleration * Time.deltaTime;
        }
        else
        {
            if (currentSpeed > 0)
                currentSpeed -= friction * Time.deltaTime;
            else if (currentSpeed < 0)
                currentSpeed += friction * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(
            currentSpeed,
            -maxReverseSpeed,
            maxForwardSpeed
        );

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        float speedFactor = Mathf.Clamp01(Mathf.Abs(currentSpeed) / maxForwardSpeed);
        transform.Rotate(Vector3.up, turnInput * turnSpeed * speedFactor * Time.deltaTime);
    }
}
