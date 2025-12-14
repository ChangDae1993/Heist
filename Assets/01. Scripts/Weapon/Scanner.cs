using UnityEngine;

namespace std
{
    public class Scanner
    {
        public int test;
    }
}

public class Scanner : MonoBehaviour
{
    public float enemyScanRadius;
    public LayerMask[] targetLayers;
    public Collider[] targets;
    public Transform nearestTarget;
    public float maxDistance;
    void Update()
    {
        targets = Physics.OverlapSphere(transform.position, enemyScanRadius, targetLayers[0]);
        nearestTarget = getNearestTrans();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 1f);

        Gizmos.DrawWireSphere(transform.position, enemyScanRadius);
    }

    public Transform getNearestTrans()
    {
        Transform result = null;
        float diff = 100;

        foreach (Collider target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if(diff > distance) {
                diff = distance;
                result = target.transform;
            }
        }
        return result;
    }
}
