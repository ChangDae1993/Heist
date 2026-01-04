using System.Collections;
using UnityEngine;

public class MeteorObj : MonoBehaviour
{
    private float damage;
    private void OnEnable()
    {
        StartCoroutine(LifeCycleCo());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    void Update()
    {
        transform.Rotate(180f * Time.deltaTime, 180f * Time.deltaTime, 180f * Time.deltaTime);
    }
    public void Init(float damage)
    {
        this.damage = damage;
    }
    IEnumerator LifeCycleCo()
    {
        yield return new WaitForSeconds(5);

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IHitAble>(out IHitAble hit))
        {
            hit.Hp -= damage;
        }
        gameObject.SetActive(false);
    }
}
