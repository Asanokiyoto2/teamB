using UnityEngine;
public class UIController : MonoBehaviour
{
    [Header("プレイヤーを指定")]
    public PlayerControll player;  // ← ここを public にして Inspector から指定できるようにする
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        // 初期状態
        anim.SetBool("Star", true);
        anim.SetBool("Hart", true);
        anim.SetBool("Circle", true);
    }
    void Update()
    {
        if (player == null) return; // ← 念のための安全チェック
        if (player.life == 3)
        {
            anim.SetBool("Star", true);
            anim.SetBool("Hart", true);
            anim.SetBool("Circle", true);
        }
        else if (player.life == 2)
        {
            anim.SetBool("Star", true);
            anim.SetBool("Hart", true);
            anim.SetBool("Circle", false);
        }
        else if (player.life == 1)
        {
            anim.SetBool("Star", true);
            anim.SetBool("Hart", false);
            anim.SetBool("Circle", false);
        }
        else if (player.life == 0)
        {
            anim.SetBool("Star", false);
            anim.SetBool("Hart", false);
            anim.SetBool("Circle", false);
        }
    }
}
