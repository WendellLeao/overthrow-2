using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [Header("Mesh Renderer")]
    [SerializeField] protected MeshRenderer _meshRenderer;
    
    [Header("Materials")]
    protected Material _startMaterial;
    
    [Header("Projectile Components")]
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Fire")]
    [SerializeField] private float _shootForce;

    public void SetProjectileForce(Transform spawnTransform)
    {
        _rigidbody.AddForce(spawnTransform.forward * _shootForce, ForceMode.Impulse);
    }
    
    protected abstract void ReturnProjectileToPool();

    protected virtual void OnDisable()
    {
        ResetProjectileVelocity();
        
        ReturnProjectileToPool();
        
        ResetMaterial();
    }
    
    protected virtual void Awake()
    {
        SetStartMaterial();
    }
    
    protected virtual void LateUpdate()
    {
        UnparentProjectile();
    }
    
    protected virtual void SetStartMaterial()
    {
        _startMaterial = _meshRenderer.material;
    }
    
    protected virtual void ResetMaterial()
    {
        _meshRenderer.material = _startMaterial;
    }
    
    private void UnparentProjectile()
    {
        if(transform.parent != null)
        {
            transform.parent = null;
        }
    }
    
    private void ResetProjectileVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}