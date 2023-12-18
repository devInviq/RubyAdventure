using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    // new structure for me.. I used to do { get; private set; }
    public bool pressedShiftButton => Input.GetKey(KeyCode.LeftShift);
    public bool playerIsAbleToMove { get; private set; }

    
    private float m_xMoveValue;
    private float m_yMoveValue;
    private Vector2 m_moveDirection;


    private void Start()
    {
        SetDefaultSettings();
    }


    private void Update()
    {
        if (playerIsAbleToMove)
        {
            GetPlayerInput();
        }
    }


    private void SetDefaultSettings()
    {
        SetPlayerIsAbleToMoveValue(true);

        m_moveDirection = Vector2.zero;
    }


    private void GetPlayerInput()
    {
        m_xMoveValue = Input.GetAxisRaw("Horizontal");
        m_yMoveValue = Input.GetAxisRaw("Vertical");
    }
    public Vector2 SetMoveDirection()
    {
        m_moveDirection.Set(m_xMoveValue, m_yMoveValue);
        return m_moveDirection;
    }

    public void SetPlayerIsAbleToMoveValue(bool isAble)
    {
        playerIsAbleToMove = isAble;
    }
}