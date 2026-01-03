using UnityEngine;

public class GarlicObj : MonoBehaviour 
{
    private float damage;
    private float scale;
    private float duration;
    private float timer;
    private bool isUp;

    private Garlic owner;

    private void Start()
    {
        isUp = true;
    }

    public void Init(Garlic owner, float damage, float scale, float duration)
    {
        this.owner = owner;
        this.damage = damage;
        this.scale = scale;
        this.duration = duration;
    }
    public void Update()
    {
        if(transform.localScale.x <= scale && isUp)
            ChangeScale(true);
        else
        {
            isUp = false;
            timer += Time.deltaTime;
            if(timer > duration)
                ChangeScale(false);
        }
    }

    private void ChangeScale(bool plus)
    {
        if(plus)
        {
            Vector3 scale = transform.localScale;
            scale.x += 0.01f;
            scale.z += 0.01f;
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x -= 0.01f;
            scale.z -= 0.01f;
            transform.localScale = scale;
            if (scale.x <= 0f)
                ResetData();
        }
    }
    private void ResetData()
    {
        timer = 0f;
        isUp = true;
        owner.IsTimer = true;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IHitAble>(out IHitAble hit))
        {
            hit.Hp -= damage;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<IHitAble>(out IHitAble hit))
        {
            hit.Hp -= damage;
        }
    }
}
