using UnityEngine;

public sealed class BallProjectile : Projectile
{
    [Header("Deactivatable Component")]
    [SerializeField] private DeactivatableObject _deactivatableObject;

    [Header("Mesh Renderer")]
    [SerializeField] private MeshRenderer _meshRenderer;
    
    [Header("Materials")]
    [SerializeField] private Material[] _startMaterial;
    [SerializeField] private Material[] _newDeactivatedMaterial;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem _particleSystem;

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

        SetParticleSystemStartColor();

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

    private void SetParticleSystemStartColor()
    {
        ParticleSystem.MainModule particleSystemMainModule = _particleSystem.main;

        Color startMaterialColor = _startMaterial[randomNumber].color;

        float customAlphaColor = 0.2f;

        particleSystemMainModule.startColor = new Color(startMaterialColor.r, startMaterialColor.g, startMaterialColor.b, customAlphaColor);
    }

    private void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.BALL_PROJECTILE, this.gameObject);
    }
}