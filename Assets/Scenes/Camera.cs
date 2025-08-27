using UnityEngine;

public class AutoScrollCamera : MonoBehaviour
{
    public float scrollSpeed = 5f;  // スクロール速度（単位：ユニット/秒）

    void Update()
    {
        // 毎フレーム、X方向にスクロール
        transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
    }
}


