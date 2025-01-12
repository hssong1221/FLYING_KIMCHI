using UnityEngine;

public class ItemSpawner : Spawner
{
    public float repeatSpeed;
    public float distance;

    private Vector3 startPosition;
    private bool direction = true;

    private void Start()
    {
        startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (direction) 
        { 
            transform.Translate(Vector3.right * repeatSpeed * Time.deltaTime);
            if (transform.position.x > startPosition.x + distance)
            {
                direction = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * repeatSpeed * Time.deltaTime);
            if (transform.position.x < startPosition.x - distance)
            {
                direction = true;
            }
        }
    }
}
