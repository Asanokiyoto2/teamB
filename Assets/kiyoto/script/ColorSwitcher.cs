/*using UnityEngine;
public class ColorSwitcher : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public SpriteRenderer playerRenderer;
    public Color blackColor = Color.black;
    public Color whiteColor = Color.white;
    [Range(0f, 1f)]
    public float stepAmount = 0f;
    public float amountMinus = 0.1f;
    private bool isWhiteBackground = true;
    void Start()
    {
        backgroundRenderer.color = whiteColor;
        playerRenderer.color = blackColor;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �w�i�ؑ�
            isWhiteBackground = !isWhiteBackground;
            Color targetBgColor = isWhiteBackground ? whiteColor : blackColor;
            backgroundRenderer.color = targetBgColor;

            stepAmount = stepAmount + amountMinus;
            // �v���C���[��w�i�Ƌt�̐F�ɐݒ�
            playerRenderer.color = isWhiteBackground ? blackColor : whiteColor;
            // �w�i�ɍ��킹�ď��X�ɓ���
            playerRenderer.color = isWhiteBackground ?
                MoveColorTowards(playerRenderer.color, whiteColor, stepAmount) :
                MoveColorTowards(playerRenderer.color, blackColor, stepAmount);
        }
    }
    private Color MoveColorTowards(Color a, Color b, float step)
    {
        float r = Mathf.MoveTowards(a.r, b.r, step);
        float g = Mathf.MoveTowards(a.g, b.g, step);
        float bl = Mathf.MoveTowards(a.b, b.b, step);
        float alpha = Mathf.MoveTowards(a.a, b.a, step);
        return new Color(r, g, bl, alpha);
    }
}*/
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


