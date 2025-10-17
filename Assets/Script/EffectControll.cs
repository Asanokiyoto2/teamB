using UnityEngine;
public class EffectControll : MonoBehaviour
{
    private Animator anim;
    public PlayerControll player;
    private int currentLife;
    private bool isPlayingEffect = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        currentLife = PlayerControll.life;
    }
    void Update()
    {
        // HPが変化したとき（＝被弾した瞬間）
        if (currentLife != PlayerControll.life)
        {
            // 以前より減っていたら被弾とみなす
            if (currentLife > PlayerControll.life)
            {
                PlayEffect();
            }
            currentLife = PlayerControll.life;
        }
        // アニメーション終了を検知して非表示に戻す
        if (isPlayingEffect)
        {
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            // アニメーションが終わったら Idle に戻す
            if (stateInfo.normalizedTime >= 1.0f && !anim.IsInTransition(0))
            {
                anim.Play("Idle"); // Idle は非表示状態のアニメ
                isPlayingEffect = false;
            }
        }
    }
    private void PlayEffect()
    {
        // トリガーリセットして確実に再生
        anim.ResetTrigger("BlackTrigger");
        anim.ResetTrigger("WhiteTrigger");
        if (player.colorSwitcher.isWhiteBackground)
        {
            anim.SetTrigger("BlackTrigger");
        }
        else
        {
            anim.SetTrigger("WhiteTrigger");
        }
        // フレーム待たず即再生
        anim.Update(0f);
        isPlayingEffect = true;
    }
}

