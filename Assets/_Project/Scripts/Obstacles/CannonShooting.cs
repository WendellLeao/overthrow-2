using System.Collections;
using UnityEngine;

public sealed class CannonShooting : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private Transform _spawnPosition;
    
    [SerializeField] private float _fireRate;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem _shootingParticleSystem;
    
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

        GameObject projectileClone = ObjectPool.instance.GetObjectFromPool(PoolType.CUBE_PROJECTILE);

        SetProjectilePosition(projectileClone);

        projectileClone.GetComponent<Projectile>().SetProjectileForce(_spawnPosition);
        
        _shootingParticleSystem.Play();

        _canShoot = true;
    }

    private void SetProjectilePosition(GameObject projectileClone)
    {
        projectileClone.transform.parent = null;

        projectileClone.transform.position = _spawnPosition.transform.position;
        projectileClone.transform.eulerAngles = Vector3.zero;
    }
}