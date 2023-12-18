using UnityEngine;

public class BasicEnemyMoving : MonoBehaviour
{
    // Reference to the movement zone Transform.
    [SerializeField] private Transform m_movingZone;

    private Rigidbody2D m_enemyRb;


    // Array of Transform objects representing the movement points within the zone.
    private Transform[] m_moveZonePoints;
    // Index of the next point to move towards.
    private int nextPointIndex;

    // Flag indicating whether the enemy can move.
    private bool m_isAbleToMove;
    // Basic movement speed of the enemy.
    private float m_baseSpeed = 4.2f;


    private void Start()
    {
        // Initialize movement points and enable movement.
        FillEnenyPointsToMoveArray();
        m_isAbleToMove = true;

        // Get enemy Rigidbody and set starting index.
        m_enemyRb = GetComponent<Rigidbody2D>();
        nextPointIndex = 0;
    }

    private void Update()
    {
        // Move enemy if allowed.
        if (m_isAbleToMove)
        {
            MoveEnemyInRandomWay();
        }
    }


    private void FillEnenyPointsToMoveArray()
    {
        // Check if the moving zone component exists.
        if (m_movingZone.TryGetComponent(out BasicEnemyMovingZone movingZone))
        {
            // Get the number of movement points from the zone.
            var pointsAmount = m_movingZone.childCount;
            // Initialize and populate the move points array.
            m_moveZonePoints = new Transform[pointsAmount];
            movingZone.GetEnemyPointsToMoveArray(m_moveZonePoints);
        }
    }


    private void MoveEnemyInRandomWay()
    {
        // Check if the enemy has reached the current point.
        OnReachNextPointPosition();

        // Calculate direction vector from current position to next point.
        Vector2 enemyCurrentPosition = m_enemyRb.position;
        Vector2 nextPointPosition = m_moveZonePoints[nextPointIndex].position;
        var direction = nextPointPosition - enemyCurrentPosition;

        // Normalize and scale direction by "speed".
        direction.Normalize();
        direction *= (m_baseSpeed * Time.deltaTime);

        // Update enemy position with calculated movement.
        m_enemyRb.MovePosition(enemyCurrentPosition + direction);
    }
    private void OnReachNextPointPosition(float minDistance = 2.0f)
    {
        Vector2 currentPosition = m_enemyRb.position;
        Vector2 nextPointPosition = m_moveZonePoints[nextPointIndex].position;

        // Calculate squared distance to current position to next point position.
        float distanceSquared = (currentPosition - nextPointPosition).sqrMagnitude;

        // Randomly change point if close enough to current one.
        if (distanceSquared < minDistance)
        {
            nextPointIndex = Random.Range(0, m_moveZonePoints.Length);
        }
    }
}