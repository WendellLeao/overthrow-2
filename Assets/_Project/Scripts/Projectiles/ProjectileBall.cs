using System.Collections;
using UnityEngine;

public sealed class ProjectileBall : Projectile
{
    private void OnDisable()
    {
        ObjectPool.instance.ReturnObjectToPool(ObjectType.PROJECTILE_BALL, this.gameObject);
    }
}