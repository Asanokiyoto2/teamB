using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControll : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10;
    private int Maxlife = 3;
    private int life;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if(collision.gameObject.CompareTag("Enemy"))
        {
            
            life--;
            Debug.Log(life);
            if (life <= 0)
            {
                Die();
            }
        }
        if(collision.gameObject.CompareTag("Item"))
        {
            if(life < 3)
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

