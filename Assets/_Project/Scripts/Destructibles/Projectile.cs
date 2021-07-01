using UnityEngine;

public sealed class Projectile : DestructibleObject
{
    [Header("Projectile Components")]
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private Rigidbody _rigidbody2D;

    [Header("Fire")]
    [SerializeField] private float _shootForce;

    public void SetProjectileVelocity(Transform spawnPosition)
    {
        _rigidbody2D.velocity = spawnPosition.forward * _shootForce;
    }

    private void Update()
    {
        CheckProjectilePosition();
    }

    private void CheckProjectilePosition()
    {
        float maximumDistanceToDisable = -120f;

        if(transform.position.y <= maximumDistanceToDisable)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        _objectPool.ReturnGameObject(this.gameObject);        
    }
}