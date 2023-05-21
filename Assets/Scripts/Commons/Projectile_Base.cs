using UnityEngine;

public class Projectile_Base : MonoBehaviour
{
    [Header("Projectile_Base")]
    public int damage;
    public Vector3 direction;
    public float projectileSpeed;
    public float timeToDestroy = 2f;
    private AudioSource audioSource;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    private void Update()
    {
        gameObject.transform.Translate(projectileSpeed * Time.deltaTime * direction);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health_Base>(out var _health_base))
        {
            _health_base.Damage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
