using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Debug.Log("Obstacle: 충돌! (감속/데미지 처리 예정)");
        // TODO: 감속 or HP 시스템 연동
    }
}
