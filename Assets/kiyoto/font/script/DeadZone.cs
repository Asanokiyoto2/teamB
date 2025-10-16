using UnityEngine;
using UnityEngine.SceneManagement; // シーンのリロード用

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        /* if (other.gameObject.CompareTag("DeadZone"))
        {
            Debug.Log("上部に当たった！プレイヤー死亡。");
            Die();
        }*/
    }

    void Die()
    {
        // 死亡処理。ここではシーンをリスタート
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

