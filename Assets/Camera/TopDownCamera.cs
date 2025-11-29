using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 20f, -4f);
    public float followLerp = 40f;

    void LateUpdate()
    {
        if (!target) 
            return;
        Vector3 desired = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desired, followLerp * Time.unscaledDeltaTime);
        transform.rotation = Quaternion.Euler(70f, 0f, 0f);
    }
}
