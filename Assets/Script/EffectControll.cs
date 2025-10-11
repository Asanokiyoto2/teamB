using UnityEngine;

public class EffectControll : MonoBehaviour

{

    private Animator anim = null;

    public PlayerControll player;

    private int currentLife;

    private bool isPlayingEffect = false;

    void Start()

    {

        anim = GetComponent<Animator>();

        currentLife = player.life;

    }

    void Update()

    {

        // HP‚ª•Ï‰»‚µ‚½‚Æ‚«i”í’e‚µ‚½uŠÔj

        if (currentLife != player.life)

        {
            // ˆÈ‘O‚æ‚èŒ¸‚Á‚Ä‚¢‚½‚ç”í’e‚Æ‚Ý‚È‚·
            if (currentLife > player.life)

            {
                
                if (player.colorSwitcher.isWhiteBackground)

                {

                    anim.SetTrigger("BlackTrigger");

                }

                else

                {

                    anim.SetTrigger("WhiteTrigger");

                }
                
            }
            currentLife = player.life;
        }

        

    }

    
}

