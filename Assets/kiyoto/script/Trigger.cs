using UnityEngine;
public class Trigger : MonoBehaviour
{
    private EnemyDrop parentIcicle;
    void Start()
    {
        parentIcicle = GetComponentInParent<EnemyDrop>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parentIcicle.TriggerFall();
        }
    }
}
