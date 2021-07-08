using UnityEngine;

public sealed class BombProjectile : Projectile
{
    [Header("Explosion")]
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _radius;

    [Header("Particle")]
    [SerializeField] private GameObject _explosionParticleObject;

    [Header("Mesh Renderer")]
    [SerializeField] private MeshRenderer _meshRenderer;
    
    private int randomNumber;

    protected override void OnDisable()
    {
        base.OnDisable();

        ResetMeshRenderer();

        ReturnProjectileToPool();
    }

    private void LateUpdate()
    {
        UnparentProjectile();
    }

    private void OnCollisionEnter(Collision other)
    {
        HandleExplosion();
    }

    private void UnparentProjectile()
    {
        if(this.transform.parent != null)
        {
            this.transform.parent = null;
        }
    }

    private void HandleExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, _radius);

        foreach(Collider nearbyObjectCollider in colliders)
        {
            if(nearbyObjectCollider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, this.transform.position, _radius);
                
                _explosionParticleObject.SetActive(true);
                
                _meshRenderer.enabled = false;
            }
        }
    }

    private void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.BOMB_PROJECTILE, this.gameObject);
    }

    private void ResetMeshRenderer()
    {
        _meshRenderer.enabled = true;
    }
}