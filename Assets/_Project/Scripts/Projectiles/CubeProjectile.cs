public sealed class CubeProjectile : Projectile, IObstacle
{
    protected override void LateUpdate()
    {
        //Empty
    }

    protected override void ReturnProjectileToPool()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.CUBE_PROJECTILE, this.gameObject);
    }
}
