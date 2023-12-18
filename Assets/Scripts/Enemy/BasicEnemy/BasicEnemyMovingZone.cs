using UnityEngine;

public class BasicEnemyMovingZone : MonoBehaviour
{
    // ======================================================================= //

    private Transform[] m_enemyMovePoints;

    // ======================================================================= //

    private void Awake()
    {
        FillEnemyPointsToMoveArray();
    }

    // ======================================================================= //

    private void FillEnemyPointsToMoveArray()
    {
        int pointsAmount = transform.childCount;
        m_enemyMovePoints = new Transform[pointsAmount];

        if (pointsAmount > 0)
        {
            for (int i = 0; i < pointsAmount; i++)
            {
                var nextPoint = transform.GetChild(i);
                m_enemyMovePoints[i] = nextPoint;
            }
        }
    }
    public void GetEnemyPointsToMoveArray(Transform[] enemyArray)
    {
        var pointsAmount = m_enemyMovePoints.Length;
        for (int i = 0; i < pointsAmount; i++)
        {
            enemyArray[i] = m_enemyMovePoints[i];
        }
    }

    // ======================================================================= //
}
