public sealed class ProjectileCube : Projectile, IObstacle
{
    private void OnDisable()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.PROJECTILE_CUBE, this.gameObject);
    }
}