using UnityEngine;

public class SetWhiteColor : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = Color.white; // オブジェクトの色を白に設定
        }
    }
}
