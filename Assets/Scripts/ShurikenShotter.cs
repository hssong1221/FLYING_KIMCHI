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
        // 타겟(플레이어)의 현재 위치에 초기 오프셋을 더해 새로운 위치 계산
        Vector2 newPosition = (Vector2)target.transform.position + initialOffset;
        // 계산된 새 위치로 이동 - 계속 같은 거리 유지 하면서 따라 다님
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
