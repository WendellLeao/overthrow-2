using System.Collections;
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

    private void Update()
    {
        StartCoroutine(CheckProjectilePosition());
    }

    private void ResetProjectileVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private IEnumerator CheckProjectilePosition()
    {
        float timeToCheck = 0.5f;

        yield return new WaitForSeconds(timeToCheck);

        float distanceToDisable = 120f;

        if(transform.position.y <= -distanceToDisable || transform.position.y >= distanceToDisable / 1.5f)
        {
            this.gameObject.SetActive(false);
        }
    }
}