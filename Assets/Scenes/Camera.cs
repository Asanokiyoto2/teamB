using UnityEngine;

public class AutoScrollCamera : MonoBehaviour
{
    public float scrollSpeed = 5f;  // �X�N���[�����x�i�P�ʁF���j�b�g/�b�j

    void Update()
    {
        // ���t���[���AX�����ɃX�N���[��
        transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
    }
}


