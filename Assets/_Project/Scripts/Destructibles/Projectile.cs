using UnityEngine;

public sealed class Projectile : DestructibleObject
{
    [Header("Projectile Components")]
    [SerializeField] private Rigidbody body;

    [Header("Fire")]
    [SerializeField] private float _shootForce;

    public void Initialize(Transform spawnPosition)
    {
        SetRigidbodyVelocity(spawnPosition);
    }

    private void SetRigidbodyVelocity(Transform spawnPosition)
    {
        body.velocity = spawnPosition.forward * _shootForce;
    }
}
