using UnityEngine;

public sealed class CubeProjectile : Projectile, IObstacle
{
    [Header(("Obstacle"))]
    [SerializeField] private int _damageToPlayerAmount;

    [Header(("Deactivatable Object"))]
    [SerializeField] private DeactivatableObject _deactivatableObject;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerDamageHandler>(out PlayerDamageHandler playerDamageHandler))
        {
            if (_deactivatableObject.IsActivated)
            {
                _deactivatableObject.IsActivated = false;
                
                playerDamageHandler.DamagePlayer(_damageToPlayerAmount);
            }
        }
    }
    
    protected override void LateUpdate()
    {
        //Empty
    }

    protected override void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.CUBE_PROJECTILE, this.gameObject);
    }
}
