using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject GameManagers;
    private PlayerInputManager m_playerInputManager;

    private Rigidbody2D m_playerRb;

    private float m_basicSpeed = 5.2f;
    private float m_rapdiSpeed = 12.4f;

    private void Start()
    {
        m_playerInputManager = GameManagers.GetComponentInChildren<PlayerInputManager>();

        m_playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool playerIsAbleToMove = m_playerInputManager.playerIsAbleToMove;

        if (playerIsAbleToMove)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        Vector2 moveDirection = m_playerInputManager.GetMoveDirection();

        if (moveDirection != Vector2.zero)
        {
            var needRapidSpeed = m_playerInputManager.pressedShiftButton;

            if (!needRapidSpeed)
            {
                moveDirection *= (m_basicSpeed * Time.deltaTime);
            }
            else
            {
                moveDirection *= (m_rapdiSpeed * Time.deltaTime);
            }

            var currentPosition = m_playerRb.position;
            var nextPosition = currentPosition + moveDirection;

            m_playerRb.MovePosition(nextPosition);
        }
    }
}
