using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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
    [Header("Player 点滅設定")]
    public float PlayerblinkDuration = 0.3f;
    public int PlayerblinkCount = 5;
    private bool isBlinking = false;
    private float blinkTimer = 0f;
    private int blinkCountRemaining = 0;
    private bool blinkVisible = true;
    [Header("Render")]
    public bool isGreen = false;
    public float greenTime = 3.0f;
    public ColorSwitcher colorScript;
    // 内部制御
    private float greenTimer = 0f;
    private bool isWaitingForBlink = false;
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
        // === 通常移動 ===
        if (!tookDamage)
        {
            noDamage = false;
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        }
        // === 緑状態タイマー ===
        if (isGreen)
        {
            greenTimer += Time.deltaTime;
            if (greenTimer >= greenTime && !isWaitingForBlink)
            {
                isWaitingForBlink = true;
                Invoke(nameof(StartBlinkWithoutCoroutine), 0f); // 緑時間後に点滅開始
            }
        }
        // === 点滅処理 ===
        if (isBlinking)
        {
            blinkTimer += Time.deltaTime;
            if (blinkTimer >= PlayerblinkDuration)
            {
                blinkTimer = 0f;
                blinkVisible = !blinkVisible;
                colorSwitcher.playerRenderer.enabled = blinkVisible;
                blinkCountRemaining--;
                if (blinkCountRemaining <= 0)
                {
                    isBlinking = false;
                    colorSwitcher.playerRenderer.enabled = true;
                    EndGreenMode(); // ← 点滅終了時に元の色へ戻す
                }
            }
        }
        // === ゴール距離更新 ===
        Vector2 pointOnGoal = goalCol.ClosestPoint(transform.position);
        Vector2 pointOnPlayer = playerCol.ClosestPoint(goal.position);
        float currentDistance = Vector2.Distance(pointOnPlayer, pointOnGoal);
        float epsilon = 0.1f;
        if (currentDistance <= epsilon) currentDistance = 0f;
        float progress = (1f - (currentDistance / startDistance)) * 50f;
        int distanceSteps = Mathf.Clamp(Mathf.RoundToInt(progress), 0, 50);
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
            ActivateGreenMode();
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
        yield return new WaitForSeconds(stateInfo.length + 0.5f);
        SceneManager.LoadScene("Game over");
    }
    // === 緑モード開始 ===
    private void ActivateGreenMode()
    {
        colorSwitcher.playerRenderer.color = colorSwitcher.greenColor;
        isGreen = true;
        greenTimer = 0f;
        isWaitingForBlink = false;
    }
    // === 点滅開始（コルーチン無し）===
    private void StartBlinkWithoutCoroutine()
    {
        isBlinking = true;
        blinkTimer = 0f;
        blinkCountRemaining = PlayerblinkCount * 2;
        blinkVisible = true;
        colorSwitcher.playerRenderer.enabled = true;
    }
    // === 緑モード終了（点滅後）===
    private void EndGreenMode()
    {
        isGreen = false;
        if (colorScript.isWhiteBackground)
            colorScript.playerRenderer.color = colorScript.blackColor;
        else
            colorScript.playerRenderer.color = colorScript.whiteColor;
    }
}


