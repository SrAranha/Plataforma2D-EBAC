using UnityEngine;

public class Health_Base : MonoBehaviour
{
    [Header("Health_Base")]
    public int startingHealth;

    private int currentHealth;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
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
        animator.SetTrigger("Death");
        Debug.Log(gameObject.name + " is dead!");
    }
    public void DestroyCharacter()
    {
        Destroy(gameObject);
    }
}
