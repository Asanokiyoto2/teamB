using UnityEngine;

using System.Collections;

public class KiyotoControll : MonoBehaviour

{

    [Header("UIオブジェクト（順にライフ3→2→1）")]

    public GameObject circleUI; // 3

    public GameObject heartUI;  // 2

    public GameObject starUI;   // 1

    [Header("プレイヤー指定")]

    public KiyotoPlayer player;

    [Header("点滅設定")]

    public float blinkDuration = 0.1f;

    public int blinkCount = 5;

    private int currentLife;

    void Start()

    {

        if (player == null)

        {

            Debug.LogError("UIController: Playerが設定されていません！");

            return;

        }

        currentLife = player.life;

        UpdateUIImmediate();

    }

    void Update()

    {

        if (player == null) return;

        // ライフ変化を検知

        if (player.life != currentLife)

        {

            StartCoroutine(ChangeUI(player.life, currentLife));

            currentLife = player.life;

        }

    }

    private IEnumerator ChangeUI(int newLife, int oldLife)

    {

        // ダメージ時

        if (newLife < oldLife)

        {

            if (oldLife == 3)

                yield return StartCoroutine(BlinkAndDisable(circleUI));

            else if (oldLife == 2)

                yield return StartCoroutine(BlinkAndDisable(heartUI));

            else if (oldLife == 1)

                yield return StartCoroutine(BlinkAndDisable(starUI));

        }

        // 回復時

        else if (newLife > oldLife)

        {

            if (newLife == 3)

                yield return StartCoroutine(ShowAndBlink(circleUI));

            else if (newLife == 2)

                yield return StartCoroutine(ShowAndBlink(heartUI));

            else if (newLife == 1)

                yield return StartCoroutine(ShowAndBlink(starUI));

        }

    }

    private IEnumerator BlinkAndDisable(GameObject obj)

    {

        if (obj == null) yield break;

        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

        if (sr == null) yield break;

        for (int i = 0; i < blinkCount; i++)

        {

            sr.enabled = !sr.enabled;

            yield return new WaitForSeconds(blinkDuration);

        }

        sr.enabled = false;

        obj.SetActive(false);

    }

    private IEnumerator ShowAndBlink(GameObject obj)

    {

        if (obj == null) yield break;

        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

        if (sr == null) yield break;

        obj.SetActive(true);

        sr.enabled = true;

        for (int i = 0; i < blinkCount; i++)

        {

            sr.enabled = !sr.enabled;

            yield return new WaitForSeconds(blinkDuration);

        }

        sr.enabled = true;

    }

    private void UpdateUIImmediate()

    {

        if (player.life >= 3)

        {

            circleUI.SetActive(true);

            heartUI.SetActive(true);

            starUI.SetActive(true);

        }

        else if (player.life == 2)

        {

            circleUI.SetActive(false);

            heartUI.SetActive(true);

            starUI.SetActive(true);

        }

        else if (player.life == 1)

        {

            circleUI.SetActive(false);

            heartUI.SetActive(false);

            starUI.SetActive(true);

        }

        else

        {

            circleUI.SetActive(false);

            heartUI.SetActive(false);

            starUI.SetActive(false);

        }

    }

}
