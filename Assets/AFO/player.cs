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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
      
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        life = Maxlife;
    }

    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        Vector2 inputDirection = new Vector2(MoveX, MoveY).normalized;

        rb.linearVelocity = new Vector2(inputDirection.x * moveSpeed, inputDirection.y * moveSpeed);

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

        spriteRenderer.enabled = true; // ÅŒã‚É•\Ž¦ó‘Ô‚É–ß‚·
        isBlinking = false;
    }






    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Game over");
    }

}
