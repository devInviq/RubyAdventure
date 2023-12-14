using UnityEngine;

public class DangeousBushesZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        var playerTag = "MainPlayerRuby";
        var collisionIsPlayer = collision.gameObject.CompareTag(playerTag);

        if (collisionIsPlayer)
        {
            var areaDamage = 0.1f;

            var playerStats = collision.gameObject.GetComponent<PlayerStats>();
            playerStats.OnPlayerTakeDamage(areaDamage);
        }
    }
}
