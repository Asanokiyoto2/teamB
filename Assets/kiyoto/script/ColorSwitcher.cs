using UnityEngine;
public class ColorSwitcher : MonoBehaviour
{
    //private PlayerControll Player;
    [Header("”wŒi‚ÆƒvƒŒƒCƒ„[")]
    public SpriteRenderer backgroundRenderer;  // ”wŒi‚ÌSpriteRenderer
    public SpriteRenderer playerRenderer;      // ƒvƒŒƒCƒ„[‚ÌSpriteRenderer
    public SpriteRenderer backgroundRenderer2;
    [Header("Fİ’è")]
    public Color blackColor = Color.black;
    public Color whiteColor = Color.white;
    public Color greenColor = Color.green;
    [Header("F‚Ì•Ï‰»‘¬“x")]
    public float colorLerpSpeed = 1f; // 1•b‚Å”wŒi‚É‹ß‚Ã‚­‘¬‚³
    public bool isWhiteBackground = true;
    public KiyotoPlayer player;
    void Start()
    {
        // ‰Šúİ’è
        backgroundRenderer.color = whiteColor;
        backgroundRenderer2.color = blackColor;
        playerRenderer.color = blackColor;

        player = GetComponent<KiyotoPlayer>();
        //player.isGreen = false;
        //Player = GetComponent<PlayerControll>();
    }
    void Update()
    {

        // SpaceƒL[‚Å”wŒiØ‚è‘Ö‚¦
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

            //if(player.isGreen == false)
            //{
            if (isWhiteBackground)
            {

                playerRenderer.color = blackColor;
                //playerRenderer.color = Color.Lerp(playerRenderer.color, backgroundRenderer.color, colorLerpSpeed * Time.deltaTime);
            }
            else
            {

                playerRenderer.color = whiteColor;
                //playerRenderer.color = Color.Lerp(playerRenderer.color, backgroundRenderer.color, colorLerpSpeed * Time.deltaTime);
            }
            //}

        }
        // ƒvƒŒƒCƒ„[‚ğ™X‚É”wŒiF‚É‹ß‚Ã‚¯‚ÄÁ‚·
        playerRenderer.color = Color.Lerp(playerRenderer.color, backgroundRenderer.color, colorLerpSpeed * Time.deltaTime);

    }

}
/*using UnityEngine;
public class ColorSwitcher : MonoBehaviour
{
    [Header("”wŒi‚ÆƒvƒŒƒCƒ„[")]
    public SpriteRenderer backgroundRenderer;  // ”wŒi‚ÌSpriteRenderer
    public SpriteRenderer playerRenderer;      // ƒvƒŒƒCƒ„[‚ÌSpriteRenderer
    public SpriteRenderer backgroundRenderer2;
    [Header("Fİ’è")]
    public Color blackColor = Color.black;
    public Color whiteColor = Color.white;
    [Header("F‚Ì•Ï‰»‘¬“x")]
    public float colorLerpSpeed = 1f; // 1•b‚Å”wŒi‚É‹ß‚Ã‚­‘¬‚³
    public bool isWhiteBackground = true;
    public KiyotoPlayer player;//
    void Start()
    {
        // ‰Šúİ’è
        backgroundRenderer.color = whiteColor;
        backgroundRenderer2.color = blackColor;
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
            backgroundRenderer2.color = isWhiteBackground ? blackColor : whiteColor;
        }
        // ƒvƒŒƒCƒ„[‚ğ™X‚É”wŒiF‚É‹ß‚Ã‚¯‚ÄÁ‚·
        playerRenderer.color = Color.Lerp(playerRenderer.color, backgroundRenderer.color, colorLerpSpeed * Time.deltaTime);
    }
    
}*/


