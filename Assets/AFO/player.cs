﻿using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10;
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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = Vector2.zero;

        Vector2 move = new Vector2(h,  v).normalized;

        rb.linearVelocity = move * moveSpeed;
    }
}
