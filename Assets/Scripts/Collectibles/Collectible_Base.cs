using UnityEngine;

public class Collectible_Base : MonoBehaviour
{
    [Header("Collectible_Base")]
    public float timeToDestroy = 1f;
    private AudioSource audioSource;
    private SpriteRenderer sprite;
    private ParticleSystem particle;
    private new Collider2D collider;

    private void OnValidate()
    {
        collider = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        particle = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        DisableSprite();
        particle.Play();
        audioSource.Play();
        Destroy(gameObject, timeToDestroy);
    }
    private void DisableSprite()
    {
        collider.enabled = false;
        sprite.gameObject.SetActive(false);
    }
}