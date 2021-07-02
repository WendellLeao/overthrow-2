using System.Collections;
using UnityEngine;

public sealed class CannonShooting : MonoBehaviour
{
    [SerializeField] private GameObject _projectileCube;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _fireRate;
    private bool _canShoot = true;

    private void Update()
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

        GameObject projectileClone = ObjectPool.instance.GetObjectFromPool(ObjectType.PROJECTILE_CUBE, _projectileCube);

        projectileClone.transform.position = _spawnPosition.transform.position;
        projectileClone.transform.rotation = _spawnPosition.transform.rotation;

        projectileClone.GetComponent<ProjectileCube>().SetProjectileVelocity(_spawnPosition);

        _canShoot = true;
    }
}