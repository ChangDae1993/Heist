using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [SerializeField] private GameConfig config;

    private Rigidbody rb;
    private float moveInput;    // -1~1

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if(config == null )
        {
            Debug.LogWarning("CarController : GameConfig not assigned.");
        }
    }

    private void FixedUpdate()
    {
        float forward = (config ? config.forwardSpeed : 15f) * Time.fixedDeltaTime;
        float lateral = (config ? config.lateralSpeed : 8f) * moveInput * Time.fixedDeltaTime;

        Vector3 next = rb.position + Vector3.forward * forward + Vector3.right * lateral;

        // move side limit
        float limit = config ? config.laneLimit : 5f;
        next.x = Mathf.Clamp(next.x, -limit, limit);

        rb.MovePosition(next);
    }

    public void SetMoveInput(float input01)
    {
        moveInput = Mathf.Clamp(input01, -1f, 1f);
    }

}
