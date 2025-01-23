using System.Collections;
using UnityEditor;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Renderer objRenderer;

    private void Start()
    {
        if(CompareTag("Food"))
        {
            objRenderer = GetComponent<Renderer>();
            Invoke("StartBlink", 5f - 1f);
            Destroy(gameObject,5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -12 || transform.position.x > 12)
        {
            Destroy(gameObject);
        }
    }

    void StartBlink()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        float timer = 0f;
        while(timer < 1f)
        {
            objRenderer.enabled = !objRenderer.enabled;
            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        objRenderer.enabled = false;
    }
}
