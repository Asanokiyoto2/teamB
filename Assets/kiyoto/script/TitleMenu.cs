using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleMenu : MonoBehaviour
{
    // �Q�[���J�n�{�^��
    public void OnStartButton()
    {
        // �Q�[���V�[���֑J��
        SceneManager.LoadScene("MainGameScene");
    }
    // �I���{�^��
    public void OnExitButton()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^�p
#endif
    }
}
