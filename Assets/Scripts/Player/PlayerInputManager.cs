using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    // !!!!!!!!!!!!!!!!!!!!!!!!!! TO REMoooooooooooooooooVEEEE !!!!!!!
    public static bool debugAction => Input.GetKey(KeyCode.RightShift);


    // DO I NEED TO USE "=>" OR CHANGE IT BACK TO { get; private set; } ???
    // THIS IS SOMETHING "NEW TO ME" ...
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

        // pressedShiftButton = Input.GetKey(KeyCode.LeftShift);
    }
    public Vector2 GetMoveDirection()
    {
        m_moveDirection.Set(m_xMoveValue, m_yMoveValue);
        return m_moveDirection;
    }



    public void SetPlayerIsAbleToMoveValue(bool isAble)
    {
        playerIsAbleToMove = isAble;
    }
}