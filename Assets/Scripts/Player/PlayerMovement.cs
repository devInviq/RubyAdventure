using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the PlayerInputManager script that handles player input.
    [SerializeField] private PlayerInputManager m_playerInputManager;

    private PlayerStats m_playerStats;
    private Rigidbody2D m_playerRb;

    // Vector2 representing the direction the player is moving in.
    private Vector2 m_moveDirection;

    // Base speed at which the player moves.
    private float m_moveSpeed;


    private void Start()
    {
        m_playerRb = GetComponent<Rigidbody2D>();
        m_playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        GetMoveDirection();
    }

    private void FixedUpdate()
    {
        // Moves the player if the player is able to move according to the PlayerInputManager.
        if (m_playerInputManager.playerIsAbleToMove == true)
        {
            MovePlayer();
        }
    }


    // Gets the move direction from the PlayerInputManager script.
    private void GetMoveDirection()
    {
        m_moveDirection = m_playerInputManager.SetMoveDirection();
    }

    // Moves the player based on the m_moveDirection member.
    private void MovePlayer()
    {
        if (m_moveDirection != Vector2.zero)
        {
            // Checking if rapid speed should be used first.
            // Returns the calculated value of the m_moveDirection member.
            CheckIfNeedToUseRapidSpeed();

            // Calculate the next position based on the move direction.
            var currentPosition = m_playerRb.position;
            var nextPosition = currentPosition + m_moveDirection;

            m_playerRb.MovePosition(nextPosition);
        }
    }

    // Checks if the shift button is pressed and adjusts the m_moveDirection member accordingly.
    private Vector2 CheckIfNeedToUseRapidSpeed()
    {
        bool moveFaster = m_playerInputManager.pressedShiftButton;

        // Apply rapid speed if shift is pressed.
        m_moveSpeed = moveFaster ? 
            m_playerStats.playerBaseMoveSpeed : m_playerStats.playerRapidMoveSpeed;

        m_moveDirection *= (m_moveSpeed * Time.deltaTime);

        return m_moveDirection;
    }
}