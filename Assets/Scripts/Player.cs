using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    private bool isJump;

    private Rigidbody2D rigidbody;
    public Animator animator;
    public BoxCollider2D collider2D;

    private bool isInvincible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            rigidbody.AddForceY(jumpForce, ForceMode2D.Impulse);
            isJump = false;
            animator.SetInteger("State", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            if (!isJump)
                animator.SetInteger("State", 2);

            isJump = true;
        }
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
        rigidbody.AddForceY(jumpForce, ForceMode2D.Impulse);
    }
}

