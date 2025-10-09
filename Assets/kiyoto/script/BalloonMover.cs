using UnityEngine;
public class BalloonMover : MonoBehaviour
{
    private Vector2 direction;
    private float speed;
    private float swayOffset;
    public void Setup(Vector2 dir, float spd)
    {
        direction = dir;
        speed = spd;
        swayOffset = Random.Range(0f, 2f * Mathf.PI); // ‰¡—h‚ê‚ÌƒYƒŒ
    }
    void Update()
    {
        // ‰¡‚É‚ä‚ç‚ä‚ç“®‚©‚·
        float sway = Mathf.Sin(Time.time * 2f + swayOffset) * 0.3f;
        transform.Translate(new Vector2(sway, direction.y) * speed * Time.deltaTime);
        // ‰æ–ÊŠO‚Éo‚½‚çíœ
        if (Mathf.Abs(transform.position.y) > 6f)
        {
            Destroy(gameObject);
        }
    }
}
