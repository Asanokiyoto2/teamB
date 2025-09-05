using UnityEngine;
using TMPro;  // TextMeshPro���g���ꍇ

public class DistanceScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private float startX;
    private float distance;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        // �ړ��������v�Z
        distance = Mathf.Max(0, transform.position.x - startX);

        // �X�R�A�����A���^�C���ōX�V
        scoreText.text = "Score: " + Mathf.FloorToInt(distance).ToString();
    }
}