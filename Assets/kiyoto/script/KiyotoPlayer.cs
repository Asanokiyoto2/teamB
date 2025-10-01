using System.Collections;

using UnityEngine;

using TMPro;

using UnityEngine.SceneManagement;

public class KiyotoPlayer : MonoBehaviour

{

    [Header("UI")]

    public TextMeshProUGUI goalDistanceText;

    public ColorSwitcher colorSwitcher;

    [Header("ゴール設定")]

    public Transform goal;

    private float startDistance;  // ゲーム開始時の距離

    [Header("ライフ設定")]

    public int Maxlife = 3;

    public int life;

    [Header("移動設定")]

    public float moveSpeed = 5f; // 移動速度

    [Header("ノックバック設定")]

    public float knockbackForce = 5f;      // ノックバックの強さ

    public float knockbackDuration = 0.2f; // ノックバックの時間

    private Rigidbody2D rb;

    private bool tookDamage = false; // ダメージ中フラグ

    private Collider2D playerCol;

    private Collider2D goalCol;

    private bool isBarrier = false;

    public bool isGreen = false;

    private float greenTime = 0;

    [SerializeField] private Sprite[] balloonSprites; // 風船のスプライト（割れる演出用）

    [SerializeField] private SpriteRenderer balloonRenderer; // 風船用SpriteRenderer

    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

        life = Maxlife;

        // コライダーを取得

        playerCol = GetComponent<Collider2D>();

        goalCol = goal.GetComponent<Collider2D>();

        // ゲーム開始時の距離を記録

        Vector2 pointOnGoal = goalCol.ClosestPoint(transform.position);

        Vector2 pointOnPlayer = playerCol.ClosestPoint(goal.position);

        startDistance = Vector2.Distance(pointOnPlayer, pointOnGoal);

        // 最初の風船スプライトをセット

        if (balloonRenderer != null && balloonSprites.Length > 0)

        {

            balloonRenderer.sprite = balloonSprites[0];

        }

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

        // ===== ゴールまでの距離計算 =====

        Vector2 pointOnGoal = goalCol.ClosestPoint(transform.position);

        Vector2 pointOnPlayer = playerCol.ClosestPoint(goal.position);

        float currentDistance = Vector2.Distance(pointOnPlayer, pointOnGoal);

        float progress = (1f - (currentDistance / startDistance)) * 50f;

        int distanceSteps = Mathf.Clamp(Mathf.FloorToInt(progress), 0, 50);

        if (currentDistance < 0.1f)

        {

            distanceSteps = 50;

        }

        if (goalDistanceText != null)

        {

            goalDistanceText.text = $"ゴールまであと: {50 - distanceSteps} / 50";

        }

        // グリーンアイテムの無敵時間

        if (isGreen)

        {

            if (Time.time - greenTime > 2.0f)

            {

                isGreen = false;

            }

        }

    }

    void OnCollisionEnter2D(Collision2D collision)

    {

        // バリアに触れたとき

        if (collision.gameObject.CompareTag("Barrier"))

        {

            isBarrier = true;

            Destroy(collision.gameObject);

        }

        // 敵に触れたとき

        if (collision.gameObject.CompareTag("Enemy") && !tookDamage)

        {

            tookDamage = true; // ★ 先にtrueで多重ヒット防止

            if (!isBarrier && !isGreen)

            {

                life--;

                UpdateBalloonSprite();

                Debug.Log("ライフ残り: " + life);

            }

            else

            {

                isBarrier = false;

            }

            if (life <= 0)

            {

                Die();

                return;

            }

            // ノックバック方向計算

            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

            StartCoroutine(ApplyKnockback(knockbackDirection));

        }

        // アイテムに触れたとき

        if (collision.gameObject.CompareTag("Item"))

        {

            if (life < Maxlife)

            {

                life++;

                UpdateBalloonSprite();

            }

            Destroy(collision.gameObject);

        }

        // ゴールに触れたとき

        if (collision.gameObject.CompareTag("Goal"))

        {

            SceneManager.LoadScene("gameclear");

        }

        // 色変えアイテム

        if (colorSwitcher.isWhiteBackground && collision.gameObject.CompareTag("Render"))

        {

            colorSwitcher.playerRenderer.color = colorSwitcher.blackColor;

            Destroy(collision.gameObject);

        }

        else if (!colorSwitcher.isWhiteBackground && collision.gameObject.CompareTag("Render"))

        {

            colorSwitcher.playerRenderer.color = colorSwitcher.whiteColor;

            Destroy(collision.gameObject);

        }

        // グリーンアイテム

        if (collision.gameObject.CompareTag("Green"))

        {

            isGreen = true;

            greenTime = Time.time;

            Destroy(collision.gameObject);

        }

    }

    // ノックバック処理

    private IEnumerator ApplyKnockback(Vector2 direction)

    {

        rb.linearVelocity = Vector2.zero;

        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        rb.linearVelocity = Vector2.zero;

        tookDamage = false;

    }

    // 死亡処理

    private void Die()

    {

        SceneManager.LoadScene("Game over");

    }

    // 風船スプライトをライフに合わせて変更

    private void UpdateBalloonSprite()

    {

        if (balloonRenderer != null && balloonSprites.Length > 0)

        {

            int index = Mathf.Clamp(Maxlife - life, 0, balloonSprites.Length - 1);

            balloonRenderer.sprite = balloonSprites[index];

        }

    }

}




