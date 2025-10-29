using UnityEngine;

public class SlowmoController : MonoBehaviour
{
    [Header("Slowmo")]
    public float slowScale = 0.4f;
    public float duration = 2f;

    private bool active;
    private float remain;

    // Update is called once per frame
    void Update()
    {
        if (!active)
            return;

        remain -= Time.unscaledDeltaTime;
        if (remain <= 0f)
            Deactivate();
    }

    public void Activate()
    {
        if(active)
        {
            remain = duration;
            return;
        }

        active = true;
        remain = duration;
        Time.timeScale = slowScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;   // Fix Physics
    }

    public void Deactivate()
    {
        active = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
