using UnityEngine;
public class BalloonSpawner : MonoBehaviour
{
    [Header("白い風船のプレハブ（複数可）")]
    public GameObject[] whiteBalloonPrefabs;
    [Header("黒い風船のプレハブ（複数可）")]
    public GameObject[] blackBalloonPrefabs;
    [Header("生成範囲設定")]
    public float leftEdge = -8f;
    public float rightEdge = 8f;
    public float centerGap = 3f;
    public float topY = 5f;
    public float bottomY = -5f;
    [Header("生成間隔")]
    public float spawnInterval = 1.2f;
    void Start()
    {
        // 交互に生成
        InvokeRepeating(nameof(SpawnWhiteBalloon), 0f, spawnInterval);
        InvokeRepeating(nameof(SpawnBlackBalloon), 0.6f, spawnInterval);
    }
    // 白い風船 → 下から上へ
    void SpawnWhiteBalloon()
    {
        if (whiteBalloonPrefabs.Length == 0) return;
        GameObject prefab = whiteBalloonPrefabs[Random.Range(0, whiteBalloonPrefabs.Length)];
        float randomX = Random.Range(leftEdge, -centerGap);
        Vector2 spawnPos = new Vector2(randomX, bottomY);
        GameObject balloon = Instantiate(prefab, spawnPos, Quaternion.identity);
        balloon.AddComponent<BalloonMover>().Setup(Vector2.up, Random.Range(0.8f, 1.8f));
    }
    // 黒い風船 → 上から下へ（見た目を逆さまに）
    void SpawnBlackBalloon()
    {
        if (blackBalloonPrefabs.Length == 0) return;
        GameObject prefab = blackBalloonPrefabs[Random.Range(0, blackBalloonPrefabs.Length)];
        float randomX = Random.Range(centerGap, rightEdge);
        Vector2 spawnPos = new Vector2(randomX, topY);
        // 通常生成
        GameObject balloon = Instantiate(prefab, spawnPos, Quaternion.identity);
        // 向きだけ反転（Prefab構造に関係なく確実に反転させる）
        balloon.transform.localScale = new Vector3(
            balloon.transform.localScale.x,
            -Mathf.Abs(balloon.transform.localScale.y),
            balloon.transform.localScale.z
        );
        // 動きは下方向（Vector2.down）でOK
        balloon.AddComponent<BalloonMover>().Setup(Vector2.down, Random.Range(0.8f, 1.8f));
    }
}

