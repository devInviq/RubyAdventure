using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovingZone : MonoBehaviour
{
    [SerializeField] Transform m_pointsToMoveParent;
    private List<Transform> m_enemyPointsToMove;


    private void Awake()
    {
        FillEnemyPointsToMoveList();
    }


    private void FillEnemyPointsToMoveList()
    {
        m_enemyPointsToMove = new List<Transform>();
        m_enemyPointsToMove.Clear();

        int pointsAmount = m_pointsToMoveParent.childCount;

        if (pointsAmount > 0)
        {
            for (int i = 0; i < pointsAmount; i++)
            {
                var nextPoint = m_pointsToMoveParent.GetChild(i);
                m_enemyPointsToMove.Add(nextPoint);
            }
        }
    }
    public void GetEnemyPointsToMove(List<Transform> newList)
    {
        var pointsAmount = m_enemyPointsToMove.Count;
        for(int i = 0; i < pointsAmount; i++)
        {
            newList.Add(m_enemyPointsToMove[i]);
        }
    }
}
