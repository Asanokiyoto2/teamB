using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;           // 移動速度
    public float leftBoundary = -10f;      // 左端の位置
    public float rightBoundary = 10f;     // 右端の位置

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // 横の移動
        float moveDistance = horizontalInput * moveSpeed * Time.deltaTime;

        // プレイヤーが左端、右端を越えないように制限
        float newXPosition = Mathf.Clamp(transform.position.x + moveDistance, leftBoundary, rightBoundary);

        // 新しい位置に移動
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}