using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using TMPro;

using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class KiyotoPlayer : MonoBehaviour

{
    private Animator anim = null;
    //anim.SetBool("damage", false)
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

    public bool isGreen = false;

    private float greenTime = 0;

    private bool noDamage = false;


    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

        life = Maxlife;

        playerCol = GetComponent<Collider2D>();

        goalCol = goal.GetComponent<Collider2D>();



        // 初期距離

        Vector2 pointOnGoal = goalCol.ClosestPoint(transform.position);

        Vector2 pointOnPlayer = playerCol.ClosestPoint(goal.position);

        startDistance = Vector2.Distance(pointOnPlayer, pointOnGoal);
        anim = GetComponent<Animator>();

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

        // ゴールまでの距離表示

        Vector2 pointOnGoal = goalCol.ClosestPoint(transform.position);

        Vector2 pointOnPlayer = playerCol.ClosestPoint(goal.position);

        float currentDistance = Vector2.Distance(pointOnPlayer, pointOnGoal);

        float progress = (1f - (currentDistance / startDistance)) * 50f;

        int distanceSteps = Mathf.Clamp(Mathf.FloorToInt(progress), 0, 50);

        if (currentDistance < 0.1f) distanceSteps = 50;

        if (goalDistanceText != null)

        {

            goalDistanceText.text = $"ゴールまであと: {50 - distanceSteps} / 50";

        }

        // 緑無敵の制限時間チェック

        if (isGreen && Time.time - greenTime > 2.0f)

        {

            isGreen = false;

        }

        // 敵との衝突まとめ処理

        

            

        

    }

    void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.CompareTag("Enemy"))

        {
            if (!isBarrier && !isGreen && !noDamage)

            {
                noDamage = true;
                life--;

                if(life == 2)
                {
                    anim.SetBool("damage", true);
                }



                if (life <= 0)

                {

                    Die();

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

        if (collision.gameObject.CompareTag("Barrier"))

        {

            isBarrier = true;

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Item"))

        {

            if (life < Maxlife)

            {

                life++;
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Goal"))

        {

            SceneManager.LoadScene("gameclear");

        }

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

    private void Die()

    {

        SceneManager.LoadScene("Game over");

    }

}





