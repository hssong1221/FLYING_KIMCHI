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
        // 타겟(플레이어)의 현재 위치에 초기 오프셋을 더해 새로운 위치 계산
        Vector2 newPosition = (Vector2)target.position + initialOffset;
        // 계산된 새 위치로 이동 - 계속 같은 거리 유지 하면서 따라 다님
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
