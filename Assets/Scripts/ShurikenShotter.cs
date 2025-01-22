using UnityEngine;

public class ShurikenShotter : MonoBehaviour
{
    public Transform target;
    private Vector2 initialOffset;
    [SerializeField]
    private bool isActive;

    private void Start()
    {
        initialOffset = (Vector2)transform.position - (Vector2)target.position;
        isActive = false;
    }

    private void Update()
    {
        // 타겟(플레이어)의 현재 위치에 초기 오프셋을 더해 새로운 위치 계산
        Vector2 newPosition = (Vector2)target.position + initialOffset;
        // 계산된 새 위치로 이동 - 계속 같은 거리 유지 하면서 따라 다님
        transform.position = newPosition;
    }

    public void SwitchShurikenShotter()
    {
        isActive = !isActive;
    }
}
