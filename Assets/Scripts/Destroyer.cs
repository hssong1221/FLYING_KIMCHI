using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -20 || transform.position.x > 20)
        {
            Destroy(gameObject);
        }
    }
}
