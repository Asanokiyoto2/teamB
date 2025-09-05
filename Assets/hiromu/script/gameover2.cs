using UnityEngine;
using UnityEngine.SceneManagement;
public class gameover2 : MonoBehaviour
{
    // ゲーム開始ボタン
    public void OnStartButton()
    {
        // ゲームシーンへ遷移
        SceneManager.LoadScene("TitleScene");
    }
    // 終了ボタン
    public void OnExitButton()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタ用
#endif
    }
}
