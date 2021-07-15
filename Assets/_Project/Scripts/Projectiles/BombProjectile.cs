using UnityEngine;

public sealed class BombProjectile : Projectile
{
    [Header("Explosion")]
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _radius;

    [Header("Particle")]
    [SerializeField] private GameObject _explosionParticleObject;

    private bool _canPlaySoundEffect = true;

    protected override void OnDisable()
    {
        base.OnDisable();

        ResetBombProjectile();
    }
    
    protected override void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.BOMB_PROJECTILE, this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        HandleExplosion();
    }

    private void HandleExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, _radius);

        foreach(Collider nearbyObjectCollider in colliders)
        {
            if(nearbyObjectCollider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, this.transform.position, _radius);

                if (_canPlaySoundEffect)
                {
                    HandleSoundEffect();
                }
                
                _explosionParticleObject.SetActive(true);
                
                _meshRenderer.enabled = false;
            }
        }
    }

    private void HandleSoundEffect()
    {
        SoundManager.instance.Play("Explosion");

        _canPlaySoundEffect = false;
    }
    
    private void ResetBombProjectile()
    {
        _explosionParticleObject.SetActive(false);
        
        _meshRenderer.enabled = true;

        _canPlaySoundEffect = true;
    }
}