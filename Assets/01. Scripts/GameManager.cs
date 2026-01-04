using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Stage")]
    [SerializeField] private GameObject ground;
    
    public GameObject player;
    

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        InitManagers();
    }
    public Vector4 GetGroundSize()
    {
        float xSize = ground.transform.localScale.x * 10.0f;
        float zSize = ground.transform.localScale.z * 10.0f;

        Vector4 groundSize;
        groundSize.x = ground.transform.position.x - xSize / 2;
        groundSize.y = ground.transform.position.x + xSize / 2;
        groundSize.z = ground.transform.position.z - zSize / 2;
        groundSize.w = ground.transform.position.z + zSize / 2;

        return groundSize;
    }
    private void InitManagers()
    {
       
    }
}
