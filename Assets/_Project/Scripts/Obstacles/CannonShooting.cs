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

    private void FixedUpdate()
    {
        if (_canShoot)
        {
            HandleShoot();
        }
    }

    private void HandleShoot()
    {
        _canShoot = false;
            
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(_fireRate);

        GameObject projectileClone = ObjectPool.instance.GetObjectFromPool(PoolType.CUBE_PROJECTILE);

        SetProjectileTransform(projectileClone.transform);
        
        FreezeProjectileRigidbodyConstraints(projectileClone);

        projectileClone.GetComponent<Projectile>().SetProjectileForce(_spawnPosition);
        
        SoundManager.instance.PlaySound3D(Sound.PLAYER_SHOOTING, transform.localPosition);
        
        _shootingParticleSystem.Play();

        _canShoot = true;
    }

    private void FreezeProjectileRigidbodyConstraints(GameObject projectileClone)
    {
        Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody>();
        
        projectileRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
    
    private void SetProjectileTransform(Transform projectileCloneTransform)
    {
        projectileCloneTransform.parent = null;

        projectileCloneTransform.position = _spawnPosition.transform.position;

        projectileCloneTransform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
