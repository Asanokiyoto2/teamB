using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // コイン取得時の処理（サウンドやスコア加算もここで可能）
            Destroy(gameObject); // コインを消す
        }
    }
}
