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

    private bool _canUnparent = true;

    public void SetProjectileForce(Transform spawnTransform)
    {
        _rigidbody.AddForce(spawnTransform.forward * _shootForce, ForceMode.Impulse);
    }
    
    protected abstract void ReturnProjectileToPool();

    protected virtual void OnDisable()
    {
        ResetProjectileVelocity();
        
        ReturnProjectileToPool();
        
        SetCanUnparent(true);
        
        ResetMaterial();
    }

    protected virtual void LateUpdate()
    {
        if (_canUnparent)
        {
            UnparentProjectile();
        }
    }

    protected virtual void ResetMaterial()
    {
        _meshRenderer.material = _startMaterial;
    }

    private void Awake()
    {
        SetStartMaterial(_meshRenderer.material);
    }
    
    private void UnparentProjectile()
    { 
        transform.parent = null;
        
        SetCanUnparent(false);
    }
    
    private void ResetProjectileVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
    }
    
    protected void SetStartMaterial(Material startMaterial)
    {
        _startMaterial = startMaterial;
    }
    
    private void SetCanUnparent(bool canUnparent)
    {
        _canUnparent = canUnparent;
    }
}
