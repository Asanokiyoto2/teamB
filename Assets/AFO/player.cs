using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10;
    private int Maxlife = 3;
    private int life;
    public float blinkDuration = 2f;       // 点滅する合計時間（秒）
    public float blinkInterval = 0.2f;     // 点滅の間隔（秒）
    private Renderer playerRenderer;
    private bool isBlinking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
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
            Destroy(collision.gameObject);
        }
    }


    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Game over");
    }

}
