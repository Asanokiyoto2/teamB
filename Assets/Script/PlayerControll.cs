using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour

{
    [Header("ゴール設定")]
    public Transform goal;
    private float startDistance;  // ゲーム開始時の距離

    [Header("ライフ設定")]

    public int Maxlife = 3;

    public int life;

    [Header("移動設定")]

    public float moveSpeed = 5f;     // 移動速度

    [Header("ノックバック設定")]

    public float knockbackForce = 5f;       // ノックバックの強さ

    public float knockbackDuration = 0.2f;  // ノックバックの時間

    private Rigidbody2D rb;

    private bool tookDamage = false; // ダメージ中フラグ

    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

        life = Maxlife;

        Collider2D playerCol = GetComponent<Collider2D>();
        Collider2D goalCol = goal.GetComponent<Collider2D>();
        Vector2 pointOnGoal = goalCol.ClosestPoint(transform.position);
        Vector2 pointOnPlayer = playerCol.ClosestPoint(goal.position);
        startDistance = Vector2.Distance(pointOnPlayer, pointOnGoal);

    }

    void Update()

    {

        // ===== 移動処理 =====

        if (!tookDamage) // ノックバック中は操作できない

        {

            float moveX = Input.GetAxis("Horizontal"); // 左右入力

            float moveY = Input.GetAxis("Vertical");   // 上下入力

            rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        }

        ///ゴールまでの距離計算///
        // 現在の距離
        float currentDistance = Vector2.Distance(transform.position, goal.position);
        // ゴールまでの進捗を 0〜50 に変換
        float progress = (1f - (currentDistance / startDistance)) * 50f;
        // 小数点切り捨てて整数化
        int distanceSteps = Mathf.Clamp(Mathf.FloorToInt(progress), 0, 50);
        Debug.Log("ゴールまであと: " + (50 - distanceSteps) + " / 50");

    }

    void OnCollisionEnter2D(Collision2D collision)

    {

        // 敵に触れたとき

        if (collision.gameObject.CompareTag("Enemy") && !tookDamage)

        {

            tookDamage = true;

            life--;

            if (life <= 0)

            {

                Die();

                return;

            }

            // ノックバック方向計算

            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

            Debug.Log("Knockback開始: " + knockbackDirection);

            StartCoroutine(ApplyKnockback(knockbackDirection));

        }

        // アイテムに触れたとき

        if (collision.gameObject.CompareTag("Item"))

        {

            if (life < Maxlife)

            {

                life++;

                

            }

            Destroy(collision.gameObject);

        }

        //ゴールに触れたとき
        if (collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("gameclear");
        }

    }

    // ノックバック処理

    private IEnumerator ApplyKnockback(Vector2 direction)

    {

        rb.linearVelocity = Vector2.zero; // いったん止める

        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        rb.linearVelocity = Vector2.zero; // ノックバック終了時に止める

        tookDamage = false; // 再びダメージを受けられるようにする

    }

    // 死亡処理

    private void Die()

    {

        SceneManager.LoadScene("Game over");

        // TODO: リスタートやシーン切り替えの処理をここに書く

    }

}

