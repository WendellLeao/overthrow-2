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
    
    [SerializeField] private float _customParticlesAlphaColor;

    private int _randomNumber;

    protected override void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.BALL_PROJECTILE, this.gameObject);
    }

    protected override void ResetMaterial()
    {
        _meshRenderer.material = _newStartMaterial[_randomNumber];
    }

    protected override void Initialize()
    {
        SetRandomNumber();

        SetParticleSystemStartColor(_newStartMaterial[_randomNumber].color);

        SetRandomDeactivatedMaterial(_newDeactivatedMaterial[_randomNumber]);
    }

    protected override void PlayCollisionSound()
    {
        //Empty
    }

    private void SetRandomNumber()
    {
        _randomNumber = Random.Range(0, _newStartMaterial.Length);
    }

    private void SetRandomDeactivatedMaterial(Material deactivatedMaterial)
    {
        _deactivatableObject.SetDeactivatedMaterial(deactivatedMaterial);
    }
    
    private void SetParticleSystemStartColor(Color startMaterialColor)
    {
        ParticleSystem.MainModule particleSystemMainModule = _particleSystem.main;

        Color newStartColor = new Color(startMaterialColor.r, startMaterialColor.g, startMaterialColor.b, _customParticlesAlphaColor);

        particleSystemMainModule.startColor = newStartColor;
    }
}
