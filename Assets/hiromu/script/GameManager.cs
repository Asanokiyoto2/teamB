using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void PlayerReachedGoal()
    {
        // �S�[���ɓ��B�������̏���
        Debug.Log("�S�[���ɓ��B���܂����I");

        // �����ŃQ�[���̏I��������A���̃X�e�[�W�ɐi�ޏ�����ǉ��ł��܂�
        // �Ⴆ�΁A�V�[����؂�ւ���ȂǁF
        // UnityEngine.SceneManagement.SceneManager.LoadScene("NextLevel");
    }
}