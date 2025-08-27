using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���L�[����
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        //�@�ړ���������
        Vector2 inputDirection = new Vector2(MoveX, MoveY).normalized;

        //�@�ړ�
        rb.linearVelocity = new Vector2(inputDirection.x * moveSpeed, inputDirection.y * moveSpeed);
    }

}
