using UnityEngine;
public class Mover : MonoBehaviour
{
    private Rigidbody2D rb;
    public BoxCollider2D boundary1;
    public BoxCollider2D boundary2;

    Collider2D collider;

    [HideInInspector]
    public bool isReverse = false;

    public float moveSpeed = 1f;
    public float pushForce = 25f; // ³¯¾Æ°¡´Â Èû

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        collider = GetComponent<Collider2D>();
        boundary1 = GameManager.Instance.boundary1;
        boundary2 = GameManager.Instance.boundary2;

        Physics2D.IgnoreCollision(collider, boundary1, true);
        Physics2D.IgnoreCollision(collider, boundary2, true);
        Physics2D.IgnoreLayerCollision(6,7,true);
    }
    // Update is called once per frame
    void Update()
    {
        if (moveSpeed == 0f)
            Debug.Log("cccccccccccccccccollision");


        if(!isReverse)
            transform.position += GameManager.Instance.CalcGameSpeed() * Time.deltaTime * Vector3.left * moveSpeed;
        else
            transform.position += GameManager.Instance.CalcGameSpeed() * Time.deltaTime * Vector3.right * moveSpeed;
    }


    Vector2 leftUP = new Vector2(-1f, 1f).normalized;
    Vector2 rightUP = new Vector2(1f, 1f).normalized;
    public void Punched()
    {
        moveSpeed = 0f;

        Vector2 pushDirection = isReverse ? leftUP : rightUP;
        rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

        collider.enabled = false;
    }
}
