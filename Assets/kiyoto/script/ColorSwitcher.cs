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


