using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            Color color = sr.color;
            color.a = 0f; // アルファ値を0に → 完全に透明
            sr.color = color;
        }
    }
}

