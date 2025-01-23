using UnityEngine;

public class SlowAura : MonoBehaviour
{
    public Transform target;
    private Vector2 initialOffset;
    [SerializeField]
    private bool isActive;
    [SerializeField]
    private float devSpeed;

    private void Start()
    {
        initialOffset = (Vector2)transform.position - (Vector2)target.position;
        isActive = false;
        devSpeed = 2f;
    }

    private void Update()
    {
        // Ÿ��(�÷��̾�)�� ���� ��ġ�� �ʱ� �������� ���� ���ο� ��ġ ���
        Vector2 newPosition = (Vector2)target.position + initialOffset;
        // ���� �� ��ġ�� �̵� - ��� ���� �Ÿ� ���� �ϸ鼭 ���� �ٴ�
        transform.position = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy slow");
            var enyobj = collision.gameObject.GetComponent<Mover>();
            enyobj.SetSpeed(devSpeed);
        }
    }

    public void SwitchSlowAura()
    {
        isActive = !isActive;
    }
}
