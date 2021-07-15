using UnityEngine;

public sealed class BallProjectile : Projectile
{
    [Header("Deactivatable Component")]
    [SerializeField] private DeactivatableObject _deactivatableObject;
    
    [Header("Materials")]
    [SerializeField] private Material[] _newStartMaterial;
    [SerializeField] private Material[] _newDeactivatedMaterial;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem _particleSystem;

    private int _randomNumber;

    protected override void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.BALL_PROJECTILE, this.gameObject);
    }

    protected override void ResetMaterial()
    {
        _meshRenderer.material = _newStartMaterial[_randomNumber];
    }

    protected override void Awake() { }

    private void Start()
    {
        SetRandomNumber();
        
        SetStartMaterial();

        SetParticleSystemStartColor();

        SetRandomDeactivatedMaterial();
    }

    private void SetRandomNumber()
    {
        _randomNumber = Random.Range(0, _newStartMaterial.Length);
    }

    protected override void SetStartMaterial()
    {
        _meshRenderer.material = _newStartMaterial[_randomNumber];
    }

    private void SetRandomDeactivatedMaterial()
    {
        _deactivatableObject.SetDeactivatedMaterial(_newDeactivatedMaterial[_randomNumber]);
    }

    private void SetParticleSystemStartColor()
    {
        ParticleSystem.MainModule particleSystemMainModule = _particleSystem.main;

        Color startMaterialColor = _newStartMaterial[_randomNumber].color;

        float customAlphaColor = 0.2f;
        
        Color newStartColor = new Color(startMaterialColor.r, startMaterialColor.g, startMaterialColor.b, customAlphaColor);

        particleSystemMainModule.startColor = newStartColor;
    }
}