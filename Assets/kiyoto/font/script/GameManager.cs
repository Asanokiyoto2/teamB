using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void PlayerReachedGoal()
    {
        // ゴールに到達した時の処理
        Debug.Log("ゴールに到達しました！");

        // ここでゲームの終了処理や、次のステージに進む処理を追加できます
        // 例えば、シーンを切り替えるなど：
        // UnityEngine.SceneManagement.SceneManager.LoadScene("NextLevel");
    }
}