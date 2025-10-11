using UnityEngine;

public class WhiteBlackToggle : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool isWhite = true;
    private float timer = 0f;
    private float switchInterval = 3f; // 5•b‚²‚Æ‚ÉØ‚è‘Ö‚¦

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white; // ‰ŠúF‚ğ”’‚Éİ’è
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            // F‚ğØ‚è‘Ö‚¦
            isWhite = !isWhite;
            sr.color = isWhite ? Color.white : Color.black;
            timer = 0f;
        }
    }
}


