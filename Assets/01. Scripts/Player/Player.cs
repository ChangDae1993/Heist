using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Speed")]
    public float maxForwardSpeed = 4f;
    public float maxReverseSpeed = 2.5f;
    public float acceleration = 10f;
    public float brakeDeceleration = 10f;
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
        float steerInput = CarInput.Instance.steer;
        float throttleInput = CarInput.Instance.throttle;

        if (throttleInput > 0)
            currentSpeed += acceleration * Time.deltaTime;
        else if (throttleInput < 0)
            currentSpeed -= brakeDeceleration * Time.deltaTime;
        else
        {
            if (currentSpeed > 0)
                currentSpeed -= friction * Time.deltaTime;
            else if (currentSpeed < 0)
                currentSpeed += friction * Time.deltaTime;
        }
        Debug.Log(acceleration);

        currentSpeed = Mathf.Clamp(
            currentSpeed,
            -maxReverseSpeed,
            maxForwardSpeed
        );

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        float speedFactor = Mathf.Clamp01(Mathf.Abs(currentSpeed) / maxForwardSpeed);
        transform.Rotate(Vector3.up, steerInput * turnSpeed * speedFactor * Time.deltaTime);
    }
}
