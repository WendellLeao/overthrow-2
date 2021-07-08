using System.Collections;
using UnityEngine;

public sealed class CannonShooting : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _fireRate;
    private bool _canShoot = true;

    private void FixedUpdate()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if(_canShoot)
        {
            _canShoot = false;
            
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(_fireRate);

        GameObject projectileClone = ObjectPool.instance.GetObjectFromPool(PoolType.CUBE_PROJECTILE);

        projectileClone.transform.parent = null;

        projectileClone.transform.position = _spawnPosition.transform.position;
        projectileClone.transform.eulerAngles = Vector3.zero;

        projectileClone.GetComponent<Projectile>().SetProjectileForce(_spawnPosition);

        _canShoot = true;
    }
}