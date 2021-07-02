using UnityEngine;

public sealed class ProjectileCube : Projectile
{
    private void OnDisable()
    {
        ObjectPool.instance.ReturnObjectToPool(ObjectType.PROJECTILE_CUBE, this.gameObject);
    }
}