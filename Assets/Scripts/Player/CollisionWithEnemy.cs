using UnityEngine;

public class CollisionWithEnemy : MonoBehaviour
{
    // A reference to the PlayerInputManager script => used to control the player's movement.
    [SerializeField] private PlayerInputManager m_playerInputManager;

    private Rigidbody2D m_playerRb;
    private BoxCollider2D m_enemyBoxCol;

    // The position point at the moment of the collision between the player and the enemy.
    private Vector2 m_collisionPosition;
    private bool m_isCollied;

    private float m_enemyDamage = 25.0f;
    private float m_xForce = 1.8f;
    private float m_yForce = 6.4f;

    private void Start()
    {
        m_playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (m_isCollied)
        {
            CheckPlayerPosition();
        }
    }


    /// <summary>
    /// This method is called when the player collides with another object.
    /// It checks if the other object is an enemy. If it is, the method applies a force to the player 
    /// and sets a flag to indicate that the player is colliding with an enemy.
    /// </summary>
    /// <param name="collision"></param>
    /// 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If collided with an enemy
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) 
        {
            // Set the collision flag to true
            m_isCollied = true;

            // Disable the player's input
            m_playerInputManager.SetPlayerIsAbleToMoveValue(false);

            var playerStats = GetComponent<PlayerStats>();
            playerStats.OnPlayerTakeDamage(m_enemyDamage);

            // Disable the enemy's collider
            m_enemyBoxCol = collision.gameObject.GetComponent<BoxCollider2D>();
            m_enemyBoxCol.enabled = false;

            // Store the collision point position
            m_collisionPosition = collision.contacts[0].point;

            // Calculate the force direction. Then apply the force to the player
            float directionX = transform.position.x - m_collisionPosition.x;
            m_playerRb.AddForce(new Vector2(Mathf.Sign(directionX) * m_xForce, m_yForce), ForceMode2D.Impulse);

            // Increase the gravity scale so the player falls
            m_playerRb.gravityScale = 1.0f;
        }
    }


    /// <summary>
    /// This method checks if the player has returned to its original position after colliding with an enemy.
    /// If it has, the method sets the colliding flag to false and resets the player's movement settings.
    /// </summary>
    /// <param name="mixValue"></param>
    private void CheckPlayerPosition(float mixValue = 0.01f)
    {
        // Check if the player is falling (negative Y velocity).
        var isFallingDown = m_playerRb.velocity.y < 0.0f;
        // Check if the player's Y position is within a small tolerance (mixValue) of the collision position.
        var isBack = (transform.position.y - m_collisionPosition.y) <= mixValue;


        // If the player is falling OR not close enough to the collision position vertically
        // If TRUE then:
        if (isFallingDown || !isBack)
        {
            // Check if the player's vertical velocity is essentially zero (e.g.: stuck on any collider)
            var isStuck = Mathf.Approximately(m_playerRb.velocity.y, 0.0f);

            // If the player is close enough vertically OR stuck, then:
            if (isBack || isStuck)
            {
                m_isCollied = false;

                SetDefaultEnemySettings();
                SetDefaultPlayerSettings();
            }
        }
    }


    // This method enables the enemy's settings (as it was before the collision).
    private void SetDefaultEnemySettings()
    {
        m_enemyBoxCol.enabled = true;
    }

    // This method resets the player's settings (as it was before the collision).
    private void SetDefaultPlayerSettings()
    {
        m_playerRb.gravityScale = 0.0f;
        m_playerRb.velocity = Vector2.zero; // Остановить игрока

        m_playerInputManager.SetPlayerIsAbleToMoveValue(true);
    }
}