using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private BoxCollider2D collider2D;
    private SpriteRenderer spriteRenderer;
    private Coroutine slowAuraCorutine;
    private Coroutine shurikenShotterCorutine;

    public BoxCollider2D rightCollider;
    public BoxCollider2D leftCollider;
    public GameObject slowAura;
    public GameObject shurikenShotter;

    public float moveSpeed = 0f;
    public float slowAuraDuration = 5f;
    public float shurikenShotterDuration = 6f;
    bool isFront = true;
    [SerializeField]
    private bool isInvincible = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isInvincible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeDirection();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            /*if (!isInvincible)
                Destroy(collision.gameObject);*/
            Destroy(collision.gameObject);
            Hit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Food"))
        {
            Destroy(collision.gameObject);
            var foodItem = collision.gameObject.GetComponent<Item>();
            if(foodItem.GetAttribute()==0)//Baechu
            {
                Heal();
            }
            else if (foodItem.GetAttribute() == 1)//Garlic
            {
                Debug.Log("slow");
                if(slowAuraCorutine == null)
                {
                    slowAuraCorutine = StartCoroutine(ActiveSlowAura());
                }
                else//duration renewal
                {
                    StopCoroutine(ActiveSlowAura());
                    slowAuraCorutine = StartCoroutine(ActiveSlowAura());
                }
            }
            else if (foodItem.GetAttribute() == 2)//Gochu
            {
                Debug.Log("shuriken");
                if(shurikenShotterCorutine == null)
                {
                    shurikenShotterCorutine = StartCoroutine(ActiveShurikenShotter());
                }
                else//duration renewal
                {
                    StopCoroutine (ActiveShurikenShotter());
                    shurikenShotterCorutine = StartCoroutine (ActiveShurikenShotter());
                }
            }
            else if (foodItem.GetAttribute() == 3)//GoldBachu
            {
                Destroy(collision.gameObject);
                StartInvincible();
            }
        }        
    }

    void Move()
    {
        float direction = isFront ? 1f : -1f;
        transform.Translate(direction * moveSpeed * Time.deltaTime * Vector3.right);
    }

    void ChangeDirection()
    {
        rightCollider.enabled = !isFront;
        leftCollider.enabled = isFront;
        isFront = !isFront;
        spriteRenderer.flipX = !isFront;
    }


    void Hit()
    {
        if (!isInvincible)
        {
            GameManager.Instance.Lives -= 1;
            if (GameManager.Instance.Lives <= 0)
                KillPlayer();
        }
    }

    void Heal()
    {
        GameManager.Instance.Lives = Mathf.Min(3, GameManager.Instance.Lives + 1);
    }

    void StartInvincible()
    {
        isInvincible = true;
        Invoke("StopInvincible", 5f);
        Debug.Log("I'm fucking invincible!");
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

    private IEnumerator ActiveSlowAura()
    {
        var slowAuraComponent = slowAura.GetComponent<SlowAura>();

        if (slowAura != null)
        {
            slowAuraComponent.SwitchSlowAura();
        }

        yield return new WaitForSeconds(slowAuraDuration);
        
        if (slowAura != null) 
        {
            slowAuraComponent.SwitchSlowAura();
        }

        slowAuraCorutine = null;
    }
    private IEnumerator ActiveShurikenShotter()
    {
        var shurikenShotterComponent = shurikenShotter.GetComponent<ShurikenShotter>();

        if (shurikenShotter != null)
        {
            shurikenShotterComponent.SwitchShurikenShotter();
        }

        yield return new WaitForSeconds(shurikenShotterDuration);

        if (shurikenShotter != null)
        {
            shurikenShotterComponent.SwitchShurikenShotter();
        }

        shurikenShotterCorutine = null;
    }

    public bool GetDirection()
    {
        return isFront;
    }
}

