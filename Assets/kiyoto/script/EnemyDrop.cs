using UnityEngine;

public class EnemyDrop : MonoBehaviour

{

    private Rigidbody2D rb;

    private bool isFalling = false;

    [Header("揺れの設定")]

    public float shakeAmount = 0.05f; // 揺れの大きさ

    public float shakeSpeed = 5f;     // 揺れる速さ

    private Vector3 startPos;

    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic; // 最初は動かない

        startPos = transform.position;

    }

    void Update()

    {

        if (!isFalling)

        {

            // サイン波で左右に揺れる

            float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

            transform.position = startPos + new Vector3(offsetX, 0f, 0f);

        }

    }

    public void TriggerFall()

    {

        if (!isFalling)

        {

            isFalling = true;

            rb.bodyType = RigidbodyType2D.Dynamic; // 落下開始

        }

    }

    void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.CompareTag("Player"))

        {
            Destroy(gameObject);
            // ライフを減らす処理をここに追加

        }

        if (collision.gameObject.CompareTag("Ground"))

        {

            Destroy(gameObject); // 地面に当たったら消える

        }

    }

}

