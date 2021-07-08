using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [Header("Projectile Components")]
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Fire")]
    [SerializeField] private float _shootForce;

    public void SetProjectileForce(Transform spawnTransform)
    {
        _rigidbody.AddForce(spawnTransform.forward * _shootForce, ForceMode.Impulse);
    }

    protected virtual void OnDisable()
    {
        ResetProjectileVelocity();
    }

    private void ResetProjectileVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}