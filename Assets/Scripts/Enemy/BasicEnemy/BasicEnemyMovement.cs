using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMoving : MonoBehaviour
{
    [SerializeField] private Transform m_movingZone;

    private Rigidbody2D m_enemyRb;

    // ======================================================================= //

    private List<Transform> m_pointsToMove;
    public bool reachedThePoint { get; private set; }
    private int nextIndex;

    // ======================================================================= //

    private bool m_enemyIsAbleToMove;
    private float m_basicSpeed = 12.4f;
    // private float m_rapidSpeed;

    // ======================================================================= //

    private void Start()
    {
        OnStartFillEnemyPointsToMoveList();
        m_enemyIsAbleToMove = true;

        m_enemyRb = GetComponent<Rigidbody2D>();
        reachedThePoint = false;
        nextIndex = 0;
    }

    private void Update()
    {
        if (m_enemyIsAbleToMove)
        {
            MoveEnemyInCircle();
        }
    }

    // ======================================================================= //

    private void OnStartFillEnemyPointsToMoveList()
    {
        m_pointsToMove = new List<Transform>();
        m_pointsToMove.Clear();

        var zoneScript = m_movingZone.gameObject.GetComponent<BasicEnemyMovingZone>();
        if (zoneScript != null)
        {
            zoneScript.GetEnemyPointsToMove(m_pointsToMove);
        }
    }

    // ======================================================================= //

    private void MoveEnemyInCircle()
    {
        Vector2 enemyCurrentPosition = m_enemyRb.position;
        Vector2 nextPointPosition = m_pointsToMove[nextIndex].position;

        var direction = nextPointPosition - enemyCurrentPosition;
        direction.Normalize();

        direction *= m_basicSpeed * Time.deltaTime;
        var newPosition = enemyCurrentPosition + direction;
        m_enemyRb.MovePosition(newPosition);

        // Debug.Log($"next point {m_pointsToMove[m_nextIndex].position}");
    }
    public void OnEnemyReachTheDestination(bool reached, int startIndex = 0, bool afterActionValue = false)
    {
        reachedThePoint = reached;

        if (reachedThePoint)
        {
            if (nextIndex >= m_pointsToMove.Count - 1)
            {
                nextIndex = startIndex;
            }
            else
            {
                nextIndex++;
            }

            reachedThePoint = afterActionValue;
        }
    }

    // ======================================================================= //
}