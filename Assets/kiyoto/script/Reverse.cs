using UnityEngine;
using UnityEngine.UI;
public class Reverse : MonoBehaviour
{
    public Image topImage;      // ã”¼•ª‚ÌImage

    private bool isDefault = true; // Œ»İ‚Ìó‘Ô‚ğ‹L˜^itrue=ã”’‰º•j

    void Start()
    {
        // ‰Šúó‘Ô‚ğİ’è
        SetDefaultColors();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ‰Ÿ‚µ‚½uŠÔ‚¾‚¯”½‰
        {
            if (isDefault)
            {
                SetAlternateColors(); // ”½“]ó‘Ô‚É‚·‚é
            }
            else
            {
                SetDefaultColors(); // Œ³‚É–ß‚·
            }
            isDefault = !isDefault; // ó‘Ô‚ğØ‚è‘Ö‚¦
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
