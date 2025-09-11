using UnityEngine;
using System.Collections;
public class EnemyDrop : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false;
    [Header("揺れる時間")]
    public float shakeDuration = 0.5f;
    [Header("揺れ幅")]
    public float shakeAmount = 0.1f;
    private Vector3 originalPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // 最初は固定
        originalPos = transform.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーが下を通ったら落下準備
        if (other.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(ShakeAndFall());
        }
    }
    IEnumerator ShakeAndFall()
    {
        isFalling = true;
        float elapsed = 0f;
        // ツララがプルプル揺れる演出
        while (elapsed < shakeDuration)
        {
            transform.position = originalPos + (Vector3)Random.insideUnitCircle * shakeAmount;
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos; // 揺れ後、元の位置に戻す
        rb.bodyType = RigidbodyType2D.Dynamic; // 重力ONで落下開始
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 地面に当たったら消える
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, 0.2f);
        }
        // プレイヤーに当たったらダメージ
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControll>().life--;
            Destroy(gameObject);
        }
    }
}
