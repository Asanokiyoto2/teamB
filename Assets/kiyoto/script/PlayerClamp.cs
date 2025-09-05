using UnityEngine;
public class PlayerClamp : MonoBehaviour
{
    private Camera mainCamera;
    private float halfHeight;
    private float halfWidth;
    private float playerHalfWidth;
    private float playerHalfHeight;
    void Start()
    {
        mainCamera = Camera.main;
        // プレイヤーのColliderのサイズを取得（なければSpriteRendererでもOK）
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        if (col != null)
        {
            playerHalfWidth = col.bounds.extents.x;
            playerHalfHeight = col.bounds.extents.y;
        }
        else
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                playerHalfWidth = sr.bounds.extents.x;
                playerHalfHeight = sr.bounds.extents.y;
            }
        }
    }
    void LateUpdate()
    {
        // カメラの半分の高さと幅を計算（Orthographicの場合）
        halfHeight = mainCamera.orthographicSize;
        halfWidth = halfHeight * mainCamera.aspect;
        // カメラの中心座標
        Vector3 camPos = mainCamera.transform.position;
        // プレイヤーの現在座標
        Vector3 pos = transform.position;
        // X座標を制限（プレイヤーの半分の幅を考慮）
        pos.x = Mathf.Clamp(pos.x, camPos.x - halfWidth + playerHalfWidth, camPos.x + halfWidth - playerHalfWidth);
        // Y座標を制限（プレイヤーの半分の高さを考慮）
        pos.y = Mathf.Clamp(pos.y, camPos.y - halfHeight + playerHalfHeight, camPos.y + halfHeight - playerHalfHeight);
        // 制限後の座標を適用
        transform.position = pos;
    }
}


