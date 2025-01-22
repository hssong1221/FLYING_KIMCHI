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
        // Ÿ��(�÷��̾�)�� ���� ��ġ�� �ʱ� �������� ���� ���ο� ��ġ ���
        Vector2 newPosition = (Vector2)target.position + initialOffset;
        // ���� �� ��ġ�� �̵� - ��� ���� �Ÿ� ���� �ϸ鼭 ���� �ٴ�
        transform.position = newPosition;
    }

    public void SwitchShurikenShotter()
    {
        isActive = !isActive;
    }
}
