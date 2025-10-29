using UnityEngine;

[RequireComponent(typeof(CarController))]
public class PlayerInput : MonoBehaviour
{
    private CarController car;
    private Vector2 lastPos;
    private bool dragging;

    [Header("Touch Sensitivity")]
    public float pixelsPerFullInput = 100f; // Drag Sesitivity

    void Awake() => car = GetComponent<CarController>();

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        float h = Input.GetAxisRaw("Horizontal");
        car.SetMoveInput(h);
#else
        float h = 0f;
        if (Input.touchCount > 0)
        {
            var t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                dragging = true;
                lastPos = t.position;
            }
            else if (t.phase == TouchPhase.Moved && dragging)
            {
                var delta = t.position - lastPos;
                lastPos = t.position;

                h = Mathf.Clamp(delta.x / pixelsPerFullInput, -1f, 1f);
            }
            else if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                dragging = false;
                h = 0f;
            }
        }
        car.SetMoveInput(h);
#endif
    }
}
