using System.Collections;
using UnityEngine;

public abstract class Projectile : DestructibleObject
{
    [Header("Projectile Components")]
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Fire")]
    [SerializeField] private float _shootForce;

    public void SetProjectileVelocity(Transform spawnPosition)
    {
        _rigidbody.velocity = spawnPosition.forward * _shootForce;
    }

    protected void Update()
    {
        StartCoroutine(CheckProjectilePosition());
    }

    protected void OnDisable()
    {
        ObjectPool.instance.ReturnObjectToPool(ObjectType.PROJECTILE_BALL, this.gameObject);
    }

    private IEnumerator CheckProjectilePosition()
    {
        float timeToCheck = 0.5f;

        yield return new WaitForSeconds(timeToCheck);

        float distanceToDisable = 120f;

        if(transform.position.y <= -distanceToDisable || transform.position.y >= distanceToDisable / 2f)
        {
            this.gameObject.SetActive(false);
        }
    }
}