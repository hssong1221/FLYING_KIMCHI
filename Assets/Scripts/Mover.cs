using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += GameManager.Instance.CalcGameSpeed() * Time.deltaTime * Vector3.left;
    }
}
