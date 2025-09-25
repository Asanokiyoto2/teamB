using UnityEngine;
using System.Collections;

public class BlinkColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isWhite = true;

    public float interval = 5f; // ì_ñ≈ÇÃä‘äuÅiïbÅj

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(BlinkLoop());
    }

    IEnumerator BlinkLoop()
    {
        while (true)
        {
            if (isWhite)
            {
                spriteRenderer.color = Color.black;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }

            isWhite = !isWhite;

            yield return new WaitForSeconds(interval);
        }
    }
}
