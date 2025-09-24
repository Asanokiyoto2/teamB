using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color color = sr.color;
            color.a = 0f; // アルファ値（0 = 完全に透明）
            sr.color = color;
        }
    }
}
