using UnityEngine;

public class PlayerGoalTrigger : MonoBehaviour
{
    public float goalPosition = 50f; // ゴール地点の位置
    public GameManager gameManager;  // ゲームマネージャーへの参照
    private bool hasReachedGoal = false; // 既にゴールしたかどうか

    void Update()
    {
        // プレイヤーが50m地点を通過したかチェック
        if (!hasReachedGoal && transform.position.x >= goalPosition)
        {
            hasReachedGoal = true; // ゴール地点を通過したフラグを立てる
            gameManager.PlayerReachedGoal(); // ゴール達成処理を呼び出す
        }
    }
}
