using UnityEngine;
using UnityEngine.InputSystem;

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
        float h = 0f;

        // 1) Keyboard (A/D, ←/→)
        if (Keyboard.current != null)
        {
            if(Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            {
                h -= 1f;
            }

            if(Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
            {
                h += 1f;
            }
        }

        // 2) Touch (Mobile)
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            var touch = Touchscreen.current.primaryTouch;
            var delta = touch.delta.ReadValue();                 // 프레임당 픽셀 변화량
            h = Mathf.Clamp(delta.x / pixelsPerFullInput, -1f, 1f);
            dragging = true;
        }
        else
        {
            // 3) Mouse Drag (Editor/PC)
            if (Mouse.current != null && Mouse.current.leftButton.isPressed)
            {
                var delta = Mouse.current.delta.ReadValue();
                h = Mathf.Clamp(delta.x / pixelsPerFullInput, -1f, 1f);
                dragging = true;
            }
            else
            {
                dragging = false;
            }
        }

        car.SetMoveInput(h);
    }
}
