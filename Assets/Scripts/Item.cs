using UnityEngine;

public class Item : MonoBehaviour
{
    public int attribute;

    private Rigidbody2D gravity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gravity = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(6, 7, true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("freeze");
        if (collision.gameObject.tag.Equals("Floor"))
        {
            gravity.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public int GetAttribute()
    {
        return attribute;
    }
}
