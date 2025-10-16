using UnityEngine;

public class WindZone2D : MonoBehaviour
{
    public float windForce = 10f; // •—‚Ì‹­‚³

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb != null)
        {
            // ã•ûŒü‚É—Í‚ğ‰Á‚¦‚éiAddForcej
            rb.AddForce(Vector2.up * windForce);
        }
    }
}
