using UnityEngine;
using UnityEngine.SceneManagement;

public class Exaplanation : MonoBehaviour
{
    public AudioClip Scenes;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Scenes);
    }

    // Update is called once per frame
    void Update()
    {
        // Enterキーが押されたらシーンを切り替える
        if (Input.GetKeyDown(KeyCode.Return))  // Return = Enterキー
        {
            SceneManager.LoadScene("Tutorial");

        }
    }
}
