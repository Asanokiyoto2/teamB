using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;           // �ړ����x
    public float leftBoundary = -10f;      // ���[�̈ʒu
    public float rightBoundary = 10f;     // �E�[�̈ʒu

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // ���̈ړ�
        float moveDistance = horizontalInput * moveSpeed * Time.deltaTime;

        // �v���C���[�����[�A�E�[���z���Ȃ��悤�ɐ���
        float newXPosition = Mathf.Clamp(transform.position.x + moveDistance, leftBoundary, rightBoundary);

        // �V�����ʒu�Ɉړ�
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}