using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class TornadoZone : MonoBehaviour
{
    [Header("風の設定")]
    [Tooltip("風の向き（例: 上方向なら (0, 1)）")]
    public Vector2 windDirection = new Vector2(0, 1);
    [Tooltip("風の強さ（数値が大きいほど強く押される）")]
    public float windForce = 5f;
    [Tooltip("風の影響を受ける時間（0なら常に影響）")]
    public float windDuration = 0f;
    [Tooltip("風の当たり判定")]
    public bool useTrigger = true;
    private void Reset()
    {
        // 自動でTrigger設定
        Collider2D col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // プレイヤー判定
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.attachedRigidbody;
            if (rb != null)
            {
                // 風の向きを正規化して押す
                Vector2 forceDir = windDirection.normalized * windForce;
                // AddForceModeをImpulseにすると強く、一瞬で押される
                rb.AddForce(forceDir, ForceMode2D.Force);
            }
        }
    }
    // コライダーがTriggerじゃない場合（通常の衝突判定用）
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!useTrigger && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.rigidbody;
            if (rb != null)
            {
                Vector2 forceDir = windDirection.normalized * windForce;
                rb.AddForce(forceDir, ForceMode2D.Force);
            }
        }
    }
    // 可視化（Sceneビューで矢印を表示）
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector3 pos = transform.position;
        Vector3 dir = new Vector3(windDirection.x, windDirection.y, 0).normalized;
        Gizmos.DrawLine(pos, pos + dir * 2f);
        Gizmos.DrawSphere(pos + dir * 2f, 0.1f);
    }
}

