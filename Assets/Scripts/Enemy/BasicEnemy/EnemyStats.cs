using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyMaxHealth { get; private set; }
    public float enemyCurrentHealth { get; private set; }


    public float enemyDefense { get; private set; }


    public float enemyBasicDamage { get; private set; }


    public float enemyRapidMoveSpeed { get; private set; }
    public float enemyBasicMoveSpeed { get; private set; }


    public bool enemyIsDead { get; private set; }


    private void Start()
    {
        enemyIsDead = false;
    }


    public void OnEnemyTakeDamage(int damage)
    {
        // Reduce health while accounting for defense
        enemyCurrentHealth -= Mathf.Max(0, damage - (enemyDefense * damage)); 
        CheckDeath();
    }

    private void CheckDeath() 
    {
        enemyIsDead = enemyCurrentHealth <= 0;
    }

    // Additional setters can be added as needed with careful validation
}