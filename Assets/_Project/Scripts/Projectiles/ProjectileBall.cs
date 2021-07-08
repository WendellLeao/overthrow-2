using UnityEngine;

public sealed class ProjectileBall : Projectile
{
    [Header("Deactivatable Component")]
    [SerializeField] private DeactivatableObject _deactivatableObject;

    [Header("Mesh Renderer")]
    [SerializeField] private MeshRenderer _meshRenderer;
    
    [Header("Materials")]
    [SerializeField] private Material[] _startMaterial;
    [SerializeField] private Material[] _newDeactivatedMaterial;

    private int randomNumber;

    protected override void OnDisable()
    {
        base.OnDisable();

        ReturnProjectileToPool();
    }

    private void Start()
    {
        SetRandomNumber();

        SetRandomStartMaterial();

        SetRandomDeactivatedMaterial();
    }

    private void LateUpdate()
    {
        UnparentProjectile();
    }

    private void UnparentProjectile()
    {
        if(this.transform.parent != null)
        {
            this.transform.parent = null;
        }
    }

    private void SetRandomNumber()
    {
        randomNumber = Random.Range(0, _startMaterial.Length);
    }

    private void SetRandomStartMaterial()
    {
        _meshRenderer.material = _startMaterial[randomNumber];
    }

    private void SetRandomDeactivatedMaterial()
    {
        _deactivatableObject.SetDeactivatedMaterial(_newDeactivatedMaterial[randomNumber]);
    }

    private void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.BALL_PROJECTILE, this.gameObject);
    }
}