using UnityEngine;
using TMPro;  // TextMeshProを使う場合

public class DistanceScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private float startX;
    private float distance;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        // 移動距離を計算
        distance = Mathf.Max(0, transform.position.x - startX);

        // スコアをリアルタイムで更新
        scoreText.text = "Score: " + Mathf.FloorToInt(distance).ToString();
    }
}