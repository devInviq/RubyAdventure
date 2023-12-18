using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Maximum health of the player
    public float playerMaxHealth { get; private set; }

    public float playerBaseMoveSpeed { get; private set; }
    public float playerRapidMoveSpeed { get; private set; }


    public float playerBaseDamage { get; private set; }
    public float playerDefense { get; private set; }


    public bool playerIsDead { get; private set; }


    // Current health of the player
    public float currentHealth { get; private set; }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(currentHealth);
        }
    }

    private void Start()
    {
        OnStartSetDefaultPlayerStats();
    }


    // Sets default player stats.
    private void OnStartSetDefaultPlayerStats()
    {
        playerIsDead = false;

        playerMaxHealth = 100.0f;
        playerBaseMoveSpeed = 5.2f;
        playerRapidMoveSpeed = 12.4f;

        currentHealth = playerMaxHealth;
    }


    // Reduces player health by a custom amount
    public void OnPlayerTakeDamage(float damageAmount, float minHealth = 0.0f)
    {
        // Calculate new health after taking damage
        float newHealth = currentHealth - damageAmount;

        // Clamp new health between 0 and max to prevent values outside valid range
        newHealth = Mathf.Clamp(newHealth, 0, playerMaxHealth);

        // Update current health to the clamped value
        currentHealth = newHealth;


        if (currentHealth <= minHealth)
        {
            playerIsDead = true;
        }
    }
}
