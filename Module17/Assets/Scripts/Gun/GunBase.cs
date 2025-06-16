using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;

    public float timeBetweenShoot = .3f;

    public Transform playerTransform;

    private Coroutine _currentCoroutine;

    private Vector3 direction;

    private void Awake()
    {
        playerTransform = GetComponentInParent<Player>().gameObject.transform;
        //playerTransform = gameObject.GetComponentInParent<Transform>();
        //O Prefab estava na posi��o Y -1.2314 ao inv�s de 0, ent�o ao inv�s de playerTransform ser
        //o transform do parent Player, foi alterado para SPR_Astronaut, j� que o prefab n�o deixava usar o parent Player.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }else if (Input.GetKeyUp(KeyCode.G))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        //projectile.side = playerSideReference.transform.localScale.x;

        direction = projectile.direction;

        if (playerTransform.rotation == new Quaternion(0, 0, 0, 0))
        {
            projectile.direction = direction; // Player virado para a direita
        }
        else if (playerTransform.rotation == new Quaternion(0, 180, 0, 0))
        {
            projectile.direction = -direction; // Player virado para a esquerda
        }
    }
}
