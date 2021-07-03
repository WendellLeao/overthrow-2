using UnityEngine;

public sealed class ProjectileCube : Projectile
{
    private void OnDisable()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.PROJECTILE_CUBE, this.gameObject);
    }
}