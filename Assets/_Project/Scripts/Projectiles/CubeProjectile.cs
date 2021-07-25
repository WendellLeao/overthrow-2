using UnityEngine;

public sealed class CubeProjectile : Projectile, IObstacle
{
    [Header(("Obstacle"))]
    [SerializeField] private int _damageToPlayerAmount;
    
    protected override void LateUpdate()
    {
        //Empty
    }

    protected override void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.CUBE_PROJECTILE, this.gameObject);
    }

    public int GetDamageToPlayerAmount()
    {
        return _damageToPlayerAmount;
    }
}
