using UnityEngine;

public class BackgoundScroll : MonoBehaviour
{
    public float scrollSpeed;
    public MeshRenderer meshRenderer;
       
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * (GameManager.Instance.CalcGameSpeed() / 20) * Time.deltaTime, 0);
    }
}
