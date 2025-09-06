using UnityEngine;

public class PlayerGoalTrigger : MonoBehaviour
{
    public float goalPosition = 50f; // �S�[���n�_�̈ʒu
    public GameManager gameManager;  // �Q�[���}�l�[�W���[�ւ̎Q��
    private bool hasReachedGoal = false; // ���ɃS�[���������ǂ���

    void Update()
    {
        // �v���C���[��50m�n�_��ʉ߂������`�F�b�N
        if (!hasReachedGoal && transform.position.x >= goalPosition)
        {
            hasReachedGoal = true; // �S�[���n�_��ʉ߂����t���O�𗧂Ă�
            gameManager.PlayerReachedGoal(); // �S�[���B���������Ăяo��
        }
    }
}
