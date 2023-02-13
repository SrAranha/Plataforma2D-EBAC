using UnityEngine;

public class Health_Base : MonoBehaviour
{
    public int startingHealth;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void Damage(int damage)
    {
        if (currentHealth <= damage)
        {
            currentHealth -= currentHealth; // This prevents the player from having negative health.
        }
        else currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    private void Kill()
    {
        Debug.Log(gameObject.name + " is dead!");
        Destroy(gameObject);
    }
}