using UnityEngine;

public sealed class ProjectileBall : Projectile
{
    [SerializeField] private Material[] _enabledMaterials, _disabledMaterials;

    private void Start()
    {
        SetRandomMaterial();
    }

    private void SetRandomMaterial()
    {
        int randomNumber = Random.Range(0, _enabledMaterials.Length);

        _meshRenderer.material = _enabledMaterials[randomNumber];

        _disabledMaterial = _disabledMaterials[randomNumber];
    }

    private void OnDisable()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.PROJECTILE_BALL, this.gameObject);
    }
}