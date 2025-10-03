using System.Collections;

using UnityEngine;

public class BalloonLife2 : MonoBehaviour

{

    [SerializeField] private SpriteRenderer balloonRenderer;

    [SerializeField] private Sprite[] balloonSprites; // 13枚 (0=新品, 12=割れ)

    private bool isAnimating = false;

    private int currentIndex = 0; // 現在のスプライト番号

    // ===== ダメージ処理 =====

    public void TakeDamage(int damage)

    {

        if (!isAnimating)

            StartCoroutine(PlayBreakAnimation(damage));

    }

    private IEnumerator PlayBreakAnimation(int count)

    {

        isAnimating = true;

        for (int i = 0; i < count; i++)

        {

            while (currentIndex < balloonSprites.Length - 1)

            {

                currentIndex++;

                balloonRenderer.sprite = balloonSprites[currentIndex];

                yield return new WaitForSeconds(0.05f);

            }

        }

        isAnimating = false;

    }

    // ===== 回復処理 =====

    public void Heal(int amount)

    {

        if (!isAnimating)

            StartCoroutine(PlayHealAnimation(amount));

    }

    private IEnumerator PlayHealAnimation(int count)

    {

        isAnimating = true;

        for (int i = 0; i < count; i++)

        {

            while (currentIndex > 0)

            {

                currentIndex--;

                balloonRenderer.sprite = balloonSprites[currentIndex];

                yield return new WaitForSeconds(0.05f);

            }

        }

        isAnimating = false;

    }

}

