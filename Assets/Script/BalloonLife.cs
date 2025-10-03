using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
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
    [Tooltip("ライフごとに割れる演出の終了インデックスを設定（例: 1個目=3, 2個目=6 ...）")]
    public int[] breakCount;
    [Header("演出設定")]
    public float breakFrameTime = 0.2f; // 割れる演出のフレーム間隔
    public int life = 3;                // 残り風船の数（初期値3）
    private bool isBreaking = false;    // 割れる演出中フラグ
    private int breakAnimation = 0;
    void Start()
    {
        UpdateBalloonSprite();
    }
    /// <summary>
    /// ダメージ処理（複数同時対応）
    /// </summary>
    public void TakeDamage(int damageAmount)
    {
        if (life <= 0) return;
        // 実際に減る分だけライフを減算
        int previousLife = life;
        life -= damageAmount;
        if (life < 0) life = 0;
        // 壊れる数を計算（前回のライフとの差分）
        int breakCountNow = previousLife - life;
        if (breakCountNow > 0)
        {
            StartCoroutine(PlayBreakAnimation(breakCountNow, life));
        }
    }
    /// <summary>
    /// 風船が壊れるアニメーション
    /// </summary>
    private IEnumerator PlayBreakAnimation(int breakNum, int remainingLife)
    {
        isBreaking = true;
        for (int i = 0; i < breakNum; i++)
        {
            // 各風船の演出を順番に再生
            for (; breakAnimation < breakCount[remainingLife + i]; breakAnimation++)
            {
                spriteRenderer.sprite = breakAnimationSprites[breakAnimation];
                yield return new WaitForSeconds(breakFrameTime);
            }
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

    internal void Heal(int v)
    {
        throw new NotImplementedException();
    }
}