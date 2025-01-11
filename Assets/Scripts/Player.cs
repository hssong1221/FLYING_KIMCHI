using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public Animator animator;
    public BoxCollider2D collider2D;
    public SpriteRenderer spriteRenderer;

    public float moveSpeed = 1f;
    bool isFront = true;

    private bool isInvincible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            if(!isInvincible)
                Destroy(collision.gameObject);
            Hit();
        }
        else if (collision.gameObject.tag.Equals("Food"))
        {
            Destroy(collision.gameObject);
            Heal();
        }
        else if (collision.gameObject.tag.Equals("Gold"))
        {
            Destroy(collision.gameObject);
            StartInvincible();
        }
    }

    void Move()
    {
        float direction = isFront ? 1f : -1f;
        transform.Translate(direction * moveSpeed * Time.deltaTime * Vector3.right);
    }

    void ChangeDirection()
    {
        isFront = !isFront;
        spriteRenderer.flipX = !isFront;
    }


    void Hit()
    {
        GameManager.Instance.Lives -= 1;
        if(GameManager.Instance.Lives <= 0)
            KillPlayer();
    }

    void Heal()
    {
        GameManager.Instance.Lives = Mathf.Min(3, GameManager.Instance.Lives + 1);
    }

    void StartInvincible()
    {
        isInvincible = true;
        Invoke("StopInvincible", 5f);
    }
    void StopInvincible()
    {
        isInvincible = false;
    }

    public void KillPlayer()
    {
        collider2D.enabled = false;
        animator.enabled = false;
    }
}

