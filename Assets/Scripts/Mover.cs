using UnityEngine;
public class Mover : MonoBehaviour
{
    [SerializeField]
    private bool isReverse = false;

    public float moveSpeed = 1f;


    // Update is called once per frame
    void Update()
    {
        if(!isReverse)
            transform.position += GameManager.Instance.CalcGameSpeed() * Time.deltaTime * Vector3.left;
        else
            transform.position += GameManager.Instance.CalcGameSpeed() * Time.deltaTime * Vector3.right;
    }
}
