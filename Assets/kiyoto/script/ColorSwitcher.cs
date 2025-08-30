using UnityEngine;
public class ColorSwitcher : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isWhite = true;  // ���݂̐F�������ǂ���
    void Start()
    {
        // ���̃I�u�W�F�N�g�� SpriteRenderer ���擾
        spriteRenderer = GetComponent<SpriteRenderer>();
        // �����F�𔒂ɐݒ�
        spriteRenderer.color = Color.white;
    }
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ��؂�ւ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isWhite)
            {
                spriteRenderer.color = Color.black;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
            // ��Ԃ𔽓]
            isWhite = !isWhite;
        }
    }
}
