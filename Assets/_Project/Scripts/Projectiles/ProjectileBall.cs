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

    private void Start()
    {
        SetRandomNumber();

        SetRandomStartMaterial();

        SetRandomDeactivatedMaterial();
    }

    private void SetRandomNumber()
    {
        randomNumber = Random.Range(0, _startMaterial.Length);
    }

    private void SetRandomStartMaterial()
    {
        _deactivatableObject.SetDeactivatedMaterial(_newDeactivatedMaterial[randomNumber]);
    }

    private void SetRandomDeactivatedMaterial()
    {
        _meshRenderer.material = _startMaterial[randomNumber];
    }

    private void OnDisable()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.PROJECTILE_BALL, this.gameObject);
    }
}