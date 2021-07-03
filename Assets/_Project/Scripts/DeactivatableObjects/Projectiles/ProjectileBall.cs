using UnityEngine;

public sealed class ProjectileBall : Projectile
{
    [Header("Materials")]
    [SerializeField] private Material[] _startMaterial;
    [SerializeField] private Material[] _newDeactivatedMaterial;

    private void Start()
    {
        SetRandomMaterial();
    }

    private void SetRandomMaterial()
    {
        int randomNumber = Random.Range(0, _startMaterial.Length);

        _meshRenderer.material = _startMaterial[randomNumber];

        _deactivatedMaterial = _newDeactivatedMaterial[randomNumber];
    }

    private void OnDisable()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.PROJECTILE_BALL, this.gameObject);
    }
}