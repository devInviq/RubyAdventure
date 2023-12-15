using UnityEngine;

public class PointToMoveTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool collisionIsEnemy = collision.gameObject.CompareTag("EnemyBasicBot");

        if (collisionIsEnemy)
        {
            var asd = collision.gameObject.GetComponent<BasicEnemyMoving>();
            asd.OnEnemyReachTheDestination(true);
        }
    }
}
