using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleMenu : MonoBehaviour
{
    // ゲーム開始ボタン
    public void OnStartButton()
    {
        // ゲームシーンへ遷移
        SceneManager.LoadScene("MainGameScene");
    }
    public void OnTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    void Update()
    {
        // Enterキーが押されたらシーンを切り替える
        if (Input.GetKeyDown(KeyCode.Return))  // Return = Enterキー
        {
            SceneManager.LoadScene("MainGameScene");
            
        }
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
