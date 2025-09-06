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
            // ”wŒiØ‘Ö
            isWhiteBackground = !isWhiteBackground;
            Color targetBgColor = isWhiteBackground ? whiteColor : blackColor;
            backgroundRenderer.color = targetBgColor;

            stepAmount = stepAmount + amountMinus;
            // ƒvƒŒƒCƒ„[‚ğ”wŒi‚Æ‹t‚ÌF‚Éİ’è
            playerRenderer.color = isWhiteBackground ? blackColor : whiteColor;
            // ”wŒi‚É‡‚í‚¹‚Ä™X‚É“¯‰»
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
    [Header("”wŒi‚ÆƒvƒŒƒCƒ„[")]
    public SpriteRenderer backgroundRenderer;  // ”wŒi‚ÌSpriteRenderer
    public SpriteRenderer playerRenderer;      // ƒvƒŒƒCƒ„[‚ÌSpriteRenderer
    [Header("Fİ’è")]
    public Color blackColor = Color.black;
    public Color whiteColor = Color.white;
    [Header("F‚Ì•Ï‰»‘¬“x")]
    public float colorLerpSpeed = 1f; // 1•b‚Å”wŒi‚É‹ß‚Ã‚­‘¬‚³
    private bool isWhiteBackground = true;
    void Start()
    {
        // ‰Šúİ’è
        backgroundRenderer.color = whiteColor;
        playerRenderer.color = blackColor;
    }
    void Update()
    {
        // SpaceƒL[‚Å”wŒiØ‚è‘Ö‚¦
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isWhiteBackground = !isWhiteBackground;
            backgroundRenderer.color = isWhiteBackground ? whiteColor : blackColor;
            // ”wŒi‚Æ‹t‚ÌF‚Éˆêu‚¾‚¯ƒvƒŒƒCƒ„[‚ğ•Ï‚¦‚é
            playerRenderer.color = isWhiteBackground ? blackColor : whiteColor;
        }
        // ƒvƒŒƒCƒ„[‚ğ™X‚É”wŒiF‚É‹ß‚Ã‚¯‚ÄÁ‚·
        playerRenderer.color = Color.Lerp(playerRenderer.color, backgroundRenderer.color, colorLerpSpeed * Time.deltaTime);
    }
}


