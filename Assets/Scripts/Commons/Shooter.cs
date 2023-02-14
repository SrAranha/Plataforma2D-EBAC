using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Projectile_Base prefabProjectile;
    public Transform shootPoint;
    public float shootCooldown;

    private Coroutine _currentCoroutine;
    // Update is called once per frame
    void Update()
    {
        // TODO: Desse modo, ao segurar o botão, têm o cooldown, mas se ficar apertando o botão, ele ignora o cooldown entre os tiros.
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            _currentCoroutine = StartCoroutine(CoroutineShoot());
        }    
        if (Input.GetKeyUp(KeyCode.Keypad0))
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
