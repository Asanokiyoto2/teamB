using UnityEngine;
public class ColorSwitcher : MonoBehaviour
{
    [Header("�w�i�ƃv���C���[")]
    public SpriteRenderer backgroundRenderer;  // �w�i��SpriteRenderer
    public SpriteRenderer playerRenderer;      // �v���C���[��SpriteRenderer
    [Header("�F�ݒ�")]
    public Color blackColor = Color.black;
    public Color whiteColor = Color.white;
    [Header("�F�̕ω����x")]
    public float colorLerpSpeed = 1f; // 1�b�Ŕw�i�ɋ߂Â�����
    private bool isWhiteBackground = true;
    void Start()
    {
        // �����ݒ�
        backgroundRenderer.color = whiteColor;
        playerRenderer.color = blackColor;
    }
    void Update()
    {
        // Space�L�[�Ŕw�i�؂�ւ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isWhiteBackground = !isWhiteBackground;
            backgroundRenderer.color = isWhiteBackground ? whiteColor : blackColor;
            // �w�i�Ƌt�̐F�Ɉ�u�����v���C���[��ς���
            playerRenderer.color = isWhiteBackground ? blackColor : whiteColor;
        }
        // �v���C���[�����X�ɔw�i�F�ɋ߂Â��ď���
        playerRenderer.color = Color.Lerp(playerRenderer.color, backgroundRenderer.color, colorLerpSpeed * Time.deltaTime);
    }
}


