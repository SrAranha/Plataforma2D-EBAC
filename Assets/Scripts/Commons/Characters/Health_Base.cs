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
            currentHealth -= currentHealth;
        }
        else currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    private void Kill()
    {
        Destroy(gameObject);
    }
}