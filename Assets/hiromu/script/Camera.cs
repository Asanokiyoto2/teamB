using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    public float baseSpeed = 2f;             // �������x
    public float accelerationAmount = 5f;    // 1�񉟂����Ƃ̉�����
    public float maxSpeed = 100f;             // �ő呬�x

    private float currentSpeed;

    void Start()
    {
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ�u�Ԃɑ��x�����Z
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed += accelerationAmount;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }

        // ��ɉE�����ɃX�N���[��
        transform.position += Vector3.right * currentSpeed * Time.deltaTime;
    }
}


