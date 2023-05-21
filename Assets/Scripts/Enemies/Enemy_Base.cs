using UnityEngine;

public class Enemy_Base : Health_Base
{
    [Header("Enemy_Base")]
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health_Base>(out var health))
        {
            health.Damage(damage);
        }
    }
}
