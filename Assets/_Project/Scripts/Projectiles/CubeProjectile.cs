using UnityEngine;

public sealed class CubeProjectile : Projectile, IObstacle
{
    [Header(("Obstacle"))]
    [SerializeField] private int _damageToPlayerAmount;

    [Header(("Deactivatable Object"))]
    [SerializeField] private DeactivatableObject _deactivatableObject;
    
    public void DamagePlayer(PlayerDamageHandler playerDamageHandler)
    {
        playerDamageHandler.DamagePlayer(_damageToPlayerAmount);
    }

    protected override void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.TryGetComponent<CubeProjectile>(out CubeProjectile cubeProjectile))
        {
            PlayCollisionSound();
        }
    }

    protected override void PlayCollisionSound()
    {
        SoundManager.instance.PlaySound3D(Sound.CUBES_COLLISION, transform.localPosition);
    }

    protected override void LateUpdate()
    {
        //Empty
    }

    protected override void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.CUBE_PROJECTILE, this.gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerDamageHandler>(out PlayerDamageHandler playerDamageHandler) && _deactivatableObject.IsActivated)
        {
            _deactivatableObject.IsActivated = false;
                
            DamagePlayer(playerDamageHandler);
        }
    }
}
