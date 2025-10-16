using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleMenu : MonoBehaviour
{

    // ゲーム開始ボタン
    
    public void OnStartMainGameScene()
    {
        // ゲームシーンへ遷移
        SceneManager.LoadScene("MainGameScene");
        
    }
    public void OnStartMainExplanation()
    {
        SceneManager.LoadScene("Explanation");
    }
    public void OnTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    void Update()
    {
        
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
