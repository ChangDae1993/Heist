using UnityEngine;

public class Bullet : MonoBehaviour, IAttackAble
{
    private Rigidbody rb;
    
    private Vector3 dir;
    
    private float speed;
    private float damage;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Init(float speed, float damage)
    {
        this.speed = speed;
        this.damage = damage;
    }
    public void FixedUpdate()
    {
       rb.linearVelocity = dir * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IHitAble>(out IHitAble hit))
        {
            Attack(other.GetComponent<IHitAble>());
        }
    }

    public void SetTarget(Transform target)
    {
        dir = (target.position - transform.position).normalized;
    }
    public void Attack(IHitAble hit)
    {
        hit.Hp -= damage;
        gameObject.SetActive(false);
    }
}
