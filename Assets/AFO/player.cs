using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10;
    private int Maxlife = 3;
    private int life;

    private SpriteRenderer spriteRenderer;
    private bool isBlinking = false;

    public float blinkDuration = 2.0f;
    public float blinkInterval = 0.2f;
    public float hoverAmplitude = 0.5f;    // 揺れの大きさ
    public float hoverFrequency = 1.0f;    // 揺れの速さ

    private Vector3 startPos;
    private float hoverTimer = 0f;
    private Animator animator;
    private bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
      
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        life = Maxlife;
        startPos = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        Vector2 inputDirection = new Vector2(MoveX, MoveY).normalized;

        rb.linearVelocity = new Vector2(inputDirection.x * moveSpeed, inputDirection.y * moveSpeed);
        hoverTimer += Time.deltaTime * hoverFrequency;
        float hoverOffset = Mathf.Sin(hoverTimer) * hoverAmplitude;

        //transform.position = new Vector3(transform.position.x, startPos.y + hoverOffset, transform.position.z);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            life--;
            Debug.Log(life);
            if (life <= 0)
            {
                Die();
            }
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            if (life < 3)
            {
                life++;
                Debug.Log(life);
            }
            StartBlinking();
            Destroy(collision.gameObject);
        }
    }

    void StartBlinking()
    {
        if (!isBlinking)
        {
            StartCoroutine(BlinkCoroutine());
        }
    }

    IEnumerator BlinkCoroutine()
    {
        isBlinking = true;
        float timer = 0f;

        while (timer < blinkDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval;
        }

        spriteRenderer.enabled = true; // 最後に表示状態に戻す
        isBlinking = false;
    }






    IEnumerator Die()
    {
        isDead = true;

        // 死亡アニメーション開始（Animatorのトリガーを使う想定）
        animator.SetTrigger("Die");

        // アニメーションの長さを取得
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animLength = stateInfo.length;

        // 死亡アニメーションの長さだけ待つ（もしくは適切な秒数）
        yield return new WaitForSeconds(animLength);

        // ゲームオーバー画面に遷移
        SceneManager.LoadScene("Game over");
    }

}
