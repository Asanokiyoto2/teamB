using UnityEngine;
using UnityEngine.UI;
public class Reverse : MonoBehaviour
{
    public Image topImage;      // �㔼����Image

    private bool isDefault = true; // ���݂̏�Ԃ��L�^�itrue=�㔒�����j

    void Start()
    {
        // ������Ԃ�ݒ�
        SetDefaultColors();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // �������u�Ԃ�������
        {
            if (isDefault)
            {
                SetAlternateColors(); // ���]��Ԃɂ���
            }
            else
            {
                SetDefaultColors(); // ���ɖ߂�
            }
            isDefault = !isDefault; // ��Ԃ�؂�ւ�
        }
    }
    private void SetDefaultColors()
    {
        topImage.color = Color.white;
       
    }
    private void SetAlternateColors()
    {
        topImage.color = Color.black;
        
    }
}
