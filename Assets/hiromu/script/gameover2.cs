using UnityEngine;
using UnityEngine.SceneManagement;
public class gameover2 : MonoBehaviour
{
    // �Q�[���J�n�{�^��
    public void OnStartButton()
    {
        // �Q�[���V�[���֑J��
        SceneManager.LoadScene("TitleScene");
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
