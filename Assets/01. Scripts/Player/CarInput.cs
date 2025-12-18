using UnityEngine;

public class CarInput : MonoBehaviour
{
    public static CarInput Instance;

    public float steer;
    public float throttle;
    bool uiSteerActive;
    bool uiThrottleActive;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        ReadKeyboardInput();
#endif
    }

    void ReadKeyboardInput()
    {
        if (!uiSteerActive)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                steer = -1f;
            else if (Input.GetKey(KeyCode.RightArrow))
                steer = 1f;
            else
                steer = 0f;
        }

        if (!uiThrottleActive)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                throttle = 1f;
            else if (Input.GetKey(KeyCode.DownArrow))
                throttle = -1f;
            else
                throttle = 0f;
        }
    }

    public void SteerLeft(bool pressed)
    {
        uiSteerActive = pressed;
        steer = pressed ? -1f : 0f;
    }

    public void SteerRight(bool pressed)
    {
        uiSteerActive = pressed;
        steer = pressed ? 1f : 0f;
    }

    public void Accelerate(bool pressed)
    {
        uiThrottleActive = pressed;
        throttle = pressed ? 1f : 0f;
    }

    public void Reverse(bool pressed)
    {
        uiThrottleActive = pressed;
        throttle = pressed ? -1f : 0f;
    }
}