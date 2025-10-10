using UnityEngine;
public class ColorSwitcher : MonoBehaviour
{
    [Header("背景とプレイヤー")]
    public SpriteRenderer backgroundRenderer;   // 背景1
    public SpriteRenderer backgroundRenderer2;  // 背景2
    public SpriteRenderer playerRenderer;       // プレイヤー
    [Header("色設定")]
    public Color blackColor = Color.black;
    public Color whiteColor = Color.white;
    public Color greenColor = Color.green;
    [Header("色の変化速度")]
    public float colorLerpSpeed = 1f; // 徐々に同化する速さ
    [Header("背景状態")]
    public bool isWhiteBackground = true;
    [Header("プレイヤー参照")]
    public PlayerControll player; // ← インスペクターで設定！
    void Start()
    {
        // 初期設定
        backgroundRenderer.color = whiteColor;
        backgroundRenderer2.color = blackColor;
        playerRenderer.color = blackColor;
    }
    void Update()
    {
        // === Spaceキーで背景切り替え ===
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isWhiteBackground = !isWhiteBackground;
            if (isWhiteBackground)
            {
                backgroundRenderer.color = whiteColor;
                backgroundRenderer2.color = blackColor;
            }
            else
            {
                backgroundRenderer.color = blackColor;
                backgroundRenderer2.color = whiteColor;
            }
            Debug.Log(player.isGreen + " Green / " + isWhiteBackground + " isWhiteBackground");
            // グリーン状態のときは色を変えない
            if (!player.isGreen)
            {
                if (isWhiteBackground)
                {
                    // 白背景 → プレイヤーを黒に一瞬変える
                    playerRenderer.color = blackColor;
                }
                else
                {
                    // 黒背景 → プレイヤーを白に一瞬変える
                    playerRenderer.color = whiteColor;
                }
            }
        }
        // === プレイヤーを徐々に背景色に近づけて同化 ===
        if (!player.isGreen) // 緑状態の時は同化しない
        {
            playerRenderer.color = Color.Lerp(
                playerRenderer.color,
                backgroundRenderer.color,
                colorLerpSpeed * Time.deltaTime
            );
        }
    }
}
/*using UnityEngine;
public class ColorSwitcher : MonoBehaviour
{
    [Header("背景とプレイヤー")]
    public SpriteRenderer backgroundRenderer;  // 背景のSpriteRenderer
    public SpriteRenderer playerRenderer;      // プレイヤーのSpriteRenderer
    public SpriteRenderer backgroundRenderer2;
    [Header("色設定")]
    public Color blackColor = Color.black;
    public Color whiteColor = Color.white;
    [Header("色の変化速度")]
    public float colorLerpSpeed = 1f; // 1秒で背景に近づく速さ
    public bool isWhiteBackground = true;
    public KiyotoPlayer player;//
    void Start()
    {
        // 初期設定
        backgroundRenderer.color = whiteColor;
        backgroundRenderer2.color = blackColor;
        playerRenderer.color = blackColor;
    }
    void Update()
    {
        // Spaceキーで背景切り替え
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isWhiteBackground = !isWhiteBackground;
            backgroundRenderer.color = isWhiteBackground ? whiteColor : blackColor;
            // 背景と逆の色に一瞬だけプレイヤーを変える
            playerRenderer.color = isWhiteBackground ? blackColor : whiteColor;
            backgroundRenderer2.color = isWhiteBackground ? blackColor : whiteColor;
        }
        // プレイヤーを徐々に背景色に近づけて消す
        playerRenderer.color = Color.Lerp(playerRenderer.color, backgroundRenderer.color, colorLerpSpeed * Time.deltaTime);
    }
    
}*/


