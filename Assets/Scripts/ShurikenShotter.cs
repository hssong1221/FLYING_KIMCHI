using System.Collections;
using UnityEngine;

public class ShurikenShotter : Spawner
{
    public GameObject target;
    public float shotInterval;
    private Vector2 initialOffset;
    [SerializeField]
    private bool isActive;
    private Player playerScript;

    private void Start()
    {
        initialOffset = (Vector2)transform.position - (Vector2)target.transform.position;
        isActive = false;
        shotInterval = 2f;
        playerScript = target.GetComponent<Player>();
        StartCoroutine(Shot());
    }

    private void Update()
    {
        // Ÿ��(�÷��̾�)�� ���� ��ġ�� �ʱ� �������� ���� ���ο� ��ġ ���
        Vector2 newPosition = (Vector2)target.transform.position + initialOffset;
        // ���� �� ��ġ�� �̵� - ��� ���� �Ÿ� ���� �ϸ鼭 ���� �ٴ�
        transform.position = newPosition;
    }

    public void SwitchShurikenShotter()
    {
        isActive = !isActive;
    }

    private IEnumerator Shot()
    {
        while (true)
        {
            if(isActive)
            {
                Spawn();
                Debug.Log("shot");
            }
            
            yield return new WaitForSeconds(shotInterval);
        }
    }

    private void OnEnable()
    {
        
    }

    protected override void Spawn()
    {
        GameObject shuriken = Instantiate(gameObjects[0], transform.position, Quaternion.identity);
        Shuriken shurikenScript = shuriken.GetComponent<Shuriken>();

        if (shurikenScript != null)
        {
            shurikenScript.SetDirection(playerScript.GetDirection());
        }
    }
}
