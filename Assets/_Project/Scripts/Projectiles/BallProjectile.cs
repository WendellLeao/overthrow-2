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

    protected override void Awake()
    {
        /// Fica a dica, ao invés de darmos override etc em metodos como "Start, Awake, Update" ou coisas do tipo o ideal é:
        /// no metodo Awake da classe base tu chama um Initialize.
        /// e ESTE sim tu pode/deve dar override entre os herdeiros (inclusive esse Initialize pode até mesmo ser abstrato)
        /// e dai cada herdeiro tem sua propria forma de inicializar.
        /// faça no Awake da classe base o que TODOS os projeteis vão realizar.
        SetRandomNumber();
        
        SetStartMaterial();

        SetParticleSystemStartColor();

        SetRandomDeactivatedMaterial();
    }
    
    protected override void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.BALL_PROJECTILE, this.gameObject);
    }

    protected override void ResetMaterial()
    {
        _meshRenderer.material = _newStartMaterial[_randomNumber];
    }
    
    protected override void SetStartMaterial()
    {
        _meshRenderer.material = _newStartMaterial[_randomNumber];
    }
    
    private void SetRandomNumber()
    {
        _randomNumber = Random.Range(0, _newStartMaterial.Length);
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