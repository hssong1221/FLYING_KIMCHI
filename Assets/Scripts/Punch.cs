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
        // Ÿ���� ���� ��ġ�� �ʱ� �������� ���� ���ο� ��ġ ���
        Vector2 newPosition = (Vector2)target.position + initialOffset;
        // ���� �� ��ġ�� �̵�
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
