using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public SpriteRenderer life1;
    public SpriteRenderer life2;
    public SpriteRenderer life3;
    public Color blackColor = Color.black;
    public Color whiteColor = Color.white;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerControll.life == 3)
        {
            life1.color = blackColor;
            life2.color = blackColor;
            life3.color = blackColor;
        }
        else if (PlayerControll.life == 2)
        {
            life1.color = whiteColor;
            life2.color = blackColor;
            life3.color = blackColor;
        }
        else if (PlayerControll.life == 1)
        {
            life1.color = whiteColor;
            life2.color = whiteColor;
            life3.color = blackColor;
        }
        lifeText.text = $"{PlayerControll.life}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
