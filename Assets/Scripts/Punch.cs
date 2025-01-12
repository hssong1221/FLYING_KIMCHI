using UnityEngine;

public class Punch : MonoBehaviour
{
    public Transform target;
    private Vector2 initialOffset;

    private void Start()
    {
        initialOffset = (Vector2)transform.position - (Vector2)target.position;
    }

    private void Update()
    {
        // 타겟의 현재 위치에 초기 오프셋을 더해 새로운 위치 계산
        Vector2 newPosition = (Vector2)target.position + initialOffset;
        // 계산된 새 위치로 이동
        transform.position = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Mover>();
            enemy.Punched();
            
        }
    }

}
