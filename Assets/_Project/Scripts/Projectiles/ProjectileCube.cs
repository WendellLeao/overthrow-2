using UnityEngine;

public sealed class ProjectileCube : Projectile, IObstacle
{
    [Header("Mesh Renderer")]
    [SerializeField] private MeshRenderer _meshRenderer;
    
    [Header("Materials")]
    private Material _startMaterial;

    protected override void OnDisable()
    {
        base.OnDisable();

        ReturnProjectileToPool();

        ResetMaterial();
    }

    private void Awake()
    {
        SetStartMaterial();
    }

    private void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.PROJECTILE_CUBE, this.gameObject);
    }

    private void ResetMaterial()
    {
        _meshRenderer.material = _startMaterial;
    }

    private void SetStartMaterial()
    {
        _startMaterial = _meshRenderer.material;
    }
}