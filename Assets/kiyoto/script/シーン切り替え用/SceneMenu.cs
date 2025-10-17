using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMenu : MonoBehaviour
{

    // ゲーム開始ボタン
    
    public void OnStartMainGameScene()
    {
        // ゲームシーンへ遷移
        SceneManager.LoadScene("MainGameScene");
        
    }
    
    public void OnTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnExplanationButton()
    {
        SceneManager.LoadScene("Tutorial");
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
