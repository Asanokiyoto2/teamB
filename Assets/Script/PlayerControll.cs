using System.Collections;

using UnityEngine;

using TMPro;

using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class PlayerControll : MonoBehaviour

{
    [Header("アニメーション")]

    private Animator anim = null;

    [Header("UI")]

    public TextMeshProUGUI goalDistanceText;

    public ColorSwitcher colorSwitcher;

    [Header("ゴール設定")]

    public Transform goal;

    private float startDistance;

    [Header("ライフ設定")]

    public int Maxlife = 3;

    public int life;

    [Header("移動設定")]

    public float moveSpeed = 5f;

    [Header("ノックバック設定")]

    public float knockbackForce = 5f;

    public float knockbackDuration = 0.2f;

    private Rigidbody2D rb;

    private bool tookDamage = false;

    private Collider2D playerCol;

    private Collider2D goalCol;

    private bool isBarrier = false;

    private bool noDamage = false;

    [Header("UI オブジェクト")]

    private GameObject Circle;

    private GameObject Star;

    private GameObject Hart;

    [Header("UI 点滅設定")]

    public float blinkDuration = 0.1f;

    public int blinkCount = 5;

    [Header("Render")]
    public bool isGreen = false;

    private float greenTime = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        life = Maxlife;

        playerCol = GetComponent<Collider2D>();

        goalCol = goal.GetComponent<Collider2D>();

        Vector2 pointOnGoal = goalCol.ClosestPoint(transform.position);

        Vector2 pointOnPlayer = playerCol.ClosestPoint(goal.position);

        startDistance = Vector2.Distance(pointOnPlayer, pointOnGoal);

        anim = GetComponent<Animator>();

        // ゲーム内オブジェクト検索

        Circle = GameObject.Find("Circle");

        Star = GameObject.Find("Star");

        Hart = GameObject.Find("Hart");
    }
    void Update()

    {

        if (!tookDamage)

        {

            noDamage = false;

            float moveX = Input.GetAxis("Horizontal");

            float moveY = Input.GetAxis("Vertical");

            rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        }

        // === ゴールまでの距離計算（コライダー表面同士） ===
        Vector2 pointOnGoal = goalCol.ClosestPoint(transform.position);
        Vector2 pointOnPlayer = playerCol.ClosestPoint(goal.position);
        float currentDistance = Vector2.Distance(pointOnPlayer, pointOnGoal);
        // === 誤差補正 ===
        // 接触しても数cm（物理誤差）残るため、一定以下なら0扱いにする
        float epsilon = 0.1f; // ← ここを0.1fなどに調整して自然に
        if (currentDistance <= epsilon)
        {
            currentDistance = 0f;
        }
        // === 距離を0〜50段階に変換 ===
        float progress = (1f - (currentDistance / startDistance)) * 50f;
        int distanceSteps = Mathf.Clamp(Mathf.RoundToInt(progress), 0, 50);
        // === UI更新 ===

        if (goalDistanceText != null)

        {

            goalDistanceText.text = $"ゴールまで残り\n {50 - distanceSteps}";

        }
    }

    void OnCollisionEnter2D(Collision2D collision)

    {

        // === 敵との接触 ===

        if (collision.gameObject.CompareTag("Enemy"))

        {
            if (!isBarrier && !isGreen && !noDamage)

            {
                noDamage = true;
                life--;
                if (life == 2)
                {
                    anim.SetBool("damage", true);

                    anim.SetBool("Heal", false);

                    Circle.SetActive(false);
                }

                else if (life == 1)
                {
                    anim.SetBool("damage2", true);

                    anim.SetBool("Heal2", false);
                }
                else if (life <= 0)
                {
                    anim.SetBool("damage3", true);
                    StartCoroutine(PlayDeathAnimationAndGameOver());
                }

            }

            else

            {

                isBarrier = false;

            }

            if (!tookDamage)

            {

                Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

                StartCoroutine(ApplyKnockback(knockbackDirection));

            }

        }

        // === バリア ===

        if (collision.gameObject.CompareTag("Barrier"))

        {

            isBarrier = true;

            Destroy(collision.gameObject);

        }

        // === 回復アイテム ===

        if (collision.gameObject.CompareTag("Item"))

        {

            if (life < Maxlife)

            {

                life++;

                if (life == 3)

                {

                    anim.SetBool("Heal", true);

                    anim.SetBool("damage", false);

                    Circle.SetActive(true);

                }

                else if (life == 2)
                {
                    anim.SetBool("Heal2", true);
                    anim.SetBool("damage2", false);
                    Hart.SetActive(true);                 
                }
            }
            Destroy(collision.gameObject);
        }

        // === ゴール到達 ===
        if (collision.gameObject.CompareTag("Goal"))

        {

            SceneManager.LoadScene("gameclear");

        }

        // === カラー反転アイテム ===
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

        // === グリーンアイテム ===

        if (collision.gameObject.CompareTag("Green"))

        {

            isGreen = true;

            greenTime = Time.time;

            Destroy(collision.gameObject);

        }

    }

    private IEnumerator ApplyKnockback(Vector2 direction)

    {

        tookDamage = true;

        rb.linearVelocity = Vector2.zero;

        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        rb.linearVelocity = Vector2.zero;

        tookDamage = false;

    }

    private IEnumerator PlayDeathAnimationAndGameOver()

    {

        rb.linearVelocity = Vector2.zero;

        tookDamage = true;

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        yield return new WaitForSeconds(stateInfo.length + 0.3f);

        SceneManager.LoadScene("Game over");

    }

    
}


