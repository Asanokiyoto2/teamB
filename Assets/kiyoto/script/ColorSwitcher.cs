using UnityEngine;
public class ColorSwitcher : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isWhite = true;  // 現在の色が白かどうか
    void Start()
    {
        // このオブジェクトの SpriteRenderer を取得
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 初期色を白に設定
        spriteRenderer.color = Color.white;
    }
    void Update()
    {
        // スペースキーが押されたら切り替え
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isWhite)
            {
                spriteRenderer.color = Color.black;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
            // 状態を反転
            isWhite = !isWhite;
        }
    }
}
