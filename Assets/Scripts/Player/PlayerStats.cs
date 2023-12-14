using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth { get; private set; }
    public float currentHealth { get; private set; }



    private void Start()
    {
        OnStartSetDefaultPlayerStats();
    }


    private void Update()
    {
        if (PlayerInputManager.debugAction)
        {
            Debug.Log($"current player health : {currentHealth}");
        }
    }


    private void OnStartSetDefaultPlayerStats()
    {
        maxHealth = 100.0f;
        currentHealth = maxHealth;
    }


    public void OnPlayerTakeDamage(float comingDamage)
    {
        currentHealth = Mathf.Clamp(currentHealth -= comingDamage, 0, maxHealth);
    }
}
