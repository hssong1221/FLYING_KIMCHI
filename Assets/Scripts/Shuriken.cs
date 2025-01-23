using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public bool direction;//true == left, false == right
    [SerializeField]
    private float shotSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shotSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!direction)
            transform.position += GameManager.Instance.CalcGameSpeed() * Time.deltaTime * Vector3.left * shotSpeed;
        else
            transform.position += GameManager.Instance.CalcGameSpeed() * Time.deltaTime * Vector3.right * shotSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("is hit?");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            var enemy = collision.GetComponent<Mover>();
            enemy.Punched();            
        }
    }

    public void SetDirection(bool inputDirc)
    {
        direction = inputDirc;
    }
}
