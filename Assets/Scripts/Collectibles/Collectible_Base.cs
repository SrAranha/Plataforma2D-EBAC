using UnityEngine;

public class Collectible_Base : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        Destroy(gameObject);
    }
}