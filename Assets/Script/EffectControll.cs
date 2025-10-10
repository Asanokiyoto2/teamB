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

        // HPが変化したとき（＝被弾した瞬間）

        if (currentLife != player.life)

        {

            // 以前より減っていたら被弾とみなす

            if (currentLife > player.life)

            {

                PlayEffectImmediately();

            }

            currentLife = player.life;

        }

        // アニメーションが終わった瞬間を検出してオフにする

        if (isPlayingEffect)

        {

            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

            if ((stateInfo.IsName("EffectBlack") || stateInfo.IsName("EffectWhite")) &&

                stateInfo.normalizedTime >= 1.0f)

            {

                anim.SetBool("isEffect", false);

                anim.SetBool("EffectBlack", false);

                anim.SetBool("EffectWhite", false);

                isPlayingEffect = false;

            }

        }

    }

    /// <summary>

    /// 集中線エフェクトを即座に再生する関数

    /// </summary>

    private void PlayEffectImmediately()

    {

        // 再生中のものをリセットしてすぐに再生

        anim.Play("Defult", 0, 0f); // ←アニメーションを一度リセット

        anim.Update(0f);          // 即座に反映させる

        anim.SetBool("isEffect", true);

        if (player.colorSwitcher.isWhiteBackground)

        {

            anim.SetBool("EffectBlack", true);

        }

        else

        {

            anim.SetBool("EffectWhite", true);

        }

        isPlayingEffect = true;

    }

}

