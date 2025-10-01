using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class BalloonLife : MonoBehaviour
{
    [Header("風船スプライト差し替え")]
    public SpriteRenderer spriteRenderer;
    // 通常のライフ状態用 (index = 残りライフ数)
    // 例: [0]なし, [1]風船1個, [2]風船2個, [3]風船3個
    public Sprite[] balloonSprites;
    [Header("割れる演出用スプライト")]
    // 風船1個分の割れるアニメーション
    public Sprite[] breakAnimationSprites;
    [Header("演出設定")]
    public float breakFrameTime = 0.2f; // 割れる演出のフレーム間隔
    public int life = 3;                // 残り風船の数（初期値3）
    private bool isBreaking = false;    // 割れる演出中フラグ
    void Start()
    {
        UpdateBalloonSprite();
    }
    /// <summary>
    /// ダメージ処理
    /// </summary>
    public void TakeDamage()
    {
        if (isBreaking || life <= 0) return;
        life--;
        // 風船が壊れる演出を開始
        StartCoroutine(PlayBreakAnimation(life));
    }
    /// <summary>
    /// 風船が壊れるアニメーション
    /// </summary>
    private IEnumerator PlayBreakAnimation(int remainingLife)
    {
        isBreaking = true;
        // 割れる演出を再生
        for (int i = 0; i < breakAnimationSprites.Length; i++)
        {
            spriteRenderer.sprite = breakAnimationSprites[i];
            yield return new WaitForSeconds(breakFrameTime);
        }
        // 演出が終わったら通常の残りライフ画像を表示
        if (remainingLife >= 0 && remainingLife < balloonSprites.Length)
        {
            spriteRenderer.sprite = balloonSprites[remainingLife];
        }
        isBreaking = false;
        // 全部なくなったらゲームオーバー
        if (life <= 0)
        {
            Die();
        }
    }
    /// <summary>
    /// 残りライフ数に応じてスプライト更新
    /// </summary>
    private void UpdateBalloonSprite()
    {
        if (life >= 0 && life < balloonSprites.Length)
        {
            spriteRenderer.sprite = balloonSprites[life];
        }
    }
    /// <summary>
    /// 全部割れたときの処理
    /// </summary>
    private void Die()
    {
        Debug.Log("GameOver!");
        SceneManager.LoadScene("GameOver"); // ← GameOverシーンを用意してね
    }
}
