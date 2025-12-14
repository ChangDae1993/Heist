using UnityEngine;

public class TestEnemy : MonoBehaviour, IHitAble
{
    [SerializeField] private float hp = 150;

    public float Hp
    {
        get => hp; 
        set => hp = value;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
