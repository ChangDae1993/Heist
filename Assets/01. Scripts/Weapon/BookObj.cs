using UnityEngine;

public class BookObj : MonoBehaviour
{
    private float damage;

    public void Init(float damage)
    {
        this.damage = damage;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IHitAble>(out IHitAble hit))
        { 
            hit.Hp -= damage;
        }
    }
}