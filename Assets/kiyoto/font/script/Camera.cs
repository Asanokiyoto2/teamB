using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    public float baseSpeed = 2f;             // 初期速度
    public float accelerationAmount = 5f;    // 1回押すごとの加速量
    public float maxSpeed = 100f;             // 最大速度

    private float currentSpeed;

    void Start()
    {
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        // スペースキーが押された瞬間に速度を加算
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed += accelerationAmount;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }

        // 常に右方向にスクロール
        transform.position += Vector3.right * currentSpeed * Time.deltaTime;
    }
}


