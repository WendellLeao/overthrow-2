using UnityEngine;

public sealed class Projectile : DestructibleObject
{
    [Header("Projectile Components")]
    [SerializeField] private Rigidbody body;

    [Header("Fire")]
    [SerializeField] private float _shootForce;

    private Transform _playerTransform;

    public void Initialize(Transform playerTransform)
    {
        _playerTransform = playerTransform;

        SetRigidbodyVelocity();
    }

    private void SetRigidbodyVelocity()
    {
        body.velocity = _playerTransform.forward * _shootForce;///
    }
}
