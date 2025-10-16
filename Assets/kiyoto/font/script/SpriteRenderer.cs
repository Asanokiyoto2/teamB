using UnityEngine;

public class WhiteBlackBlink : MonoBehaviour
{
    public float blinkInterval = 0.5f; // “_–ÅŠÔŠu

    private SpriteRenderer spriteRenderer;
    private bool isWhite = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(ToggleColor), 0f, blinkInterval);
    }

    void ToggleColor()
    {
        if (isWhite)
            spriteRenderer.color = Color.black;
        else
            spriteRenderer.color = Color.white;

        isWhite = !isWhite;
    }
}
