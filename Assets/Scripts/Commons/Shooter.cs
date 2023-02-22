using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Projectile_Base prefabProjectile;
    public Transform shootPoint;
    public float shootCooldown;

    private PlayerController player;
    private Coroutine _currentCoroutine;
    private void Awake()
    {
        player = GetComponent<PlayerController>();
        shootPoint = player.currentPlayer.transform.Find("SPR_Astronaut/Cannon/ShootPoint");
    }
    // Update is called once per frame
    void Update()
    {
        // TODO: Desse modo, ao segurar o botão, têm o cooldown, mas se ficar apertando o botão, ele ignora o cooldown entre os tiros.
        if (Input.GetKeyDown(player.keybinds.shoot))
        {
            _currentCoroutine = StartCoroutine(CoroutineShoot());
        }    
        if (Input.GetKeyUp(player.keybinds.shoot))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator CoroutineShoot()
    {
        while (true)
        {
            Shoot();   
            yield return new WaitForSeconds(shootCooldown);
        }
    }
    private void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = shootPoint.position;
        projectile.direction = new Vector3(gameObject.transform.localScale.x, 0, 0);
    }
}
