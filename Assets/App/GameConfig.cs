using UnityEngine;

[CreateAssetMenu(menuName ="Heist/GameConfig")]

public class GameConfig : MonoBehaviour
{
    [Header("Speed")]
    public float forwardSpeed = 15f;     // basic move forward speed
    public float lateralSpeed = 8f;     // basic move side speed
    public float laneLimit = 5f;        // limit move side

    [Header("Road")]
    public float chunkLength = 30f;     // chunk length;
    public int initialChunks = 6;       // initial chunk count;
}
