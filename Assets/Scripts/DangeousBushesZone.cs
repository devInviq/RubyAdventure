using UnityEngine;

public class DangeousBushesZone : MonoBehaviour
{
    private string m_playerTag = "MainPlayerRuby";
    private float m_bushesDamege = 0.1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        var isPlayer = collision.gameObject.CompareTag(m_playerTag);

        if (isPlayer)
        {
            var playerStats = collision.gameObject.GetComponent<PlayerStats>();
            playerStats.OnPlayerTakeDamage(m_bushesDamege);
        }
    }
}
