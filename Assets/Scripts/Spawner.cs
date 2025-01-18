using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minSpawnDelay;
    public float maxSpawnDelay;

    public float spawnRateIncreaseInterval = 10f; // ���� �ӵ��� ������ų ���� (��)
    public float spawnRateIncreaseAmount = 0.1f; // ���� �ӵ� ������

    public GameObject[] gameObjects;

    private float timer;

    void OnEnable()
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
        timer = 0f;

    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRateIncreaseInterval)
        {
            IncreaseSpawnRate();
            timer = 0f;
        }
    }

    void Spawn()
    {
        GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    void IncreaseSpawnRate()
    {
        minSpawnDelay = Mathf.Max(minSpawnDelay - spawnRateIncreaseAmount, 0.05f);
        maxSpawnDelay = Mathf.Max(maxSpawnDelay - spawnRateIncreaseAmount, minSpawnDelay + 0.1f);
    }
}
