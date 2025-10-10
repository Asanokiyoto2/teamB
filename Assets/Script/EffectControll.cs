using UnityEngine;
using System.Collections;
public class EffectControll : MonoBehaviour
{
    private Animator anim = null;
    public PlayerControll player;
    private int currentLife;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        currentLife = player.life;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLife != player.life)
        {
            Debug.Log("Effect");
            if (currentLife > player.life)
            {
                anim.SetBool("isEffect", true);
                if (player.colorSwitcher.isWhiteBackground)
                {
                    anim.SetBool("EffectBlack", true);
                    StartCoroutine(ChangeEffect());
                }
                else if (!player.colorSwitcher.isWhiteBackground)
                {
                    anim.SetBool("EffectWhite", true);
                    StartCoroutine(ChangeEffect());
                }
            }
            currentLife = player.life;
            
        }
        
    }
    private IEnumerator ChangeEffect()
    {   
                AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                yield return new WaitForSeconds(stateInfo.length);
        anim.SetBool("isEffect", false);
        anim.SetBool("EffectBlack", false);
        anim.SetBool("EffectWhite", false);
    }
}
