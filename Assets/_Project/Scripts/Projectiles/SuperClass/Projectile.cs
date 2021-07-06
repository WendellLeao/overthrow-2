using System.Collections;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [Header("Projectile Components")]
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Fire")]
    [SerializeField] private float _shootForce;

    public void SetProjectileVelocity(Transform spawnTransform)
    {
        _rigidbody.AddForce(spawnTransform.forward * _shootForce, ForceMode.Impulse);
    }

    protected void Update()
    {
        StartCoroutine(CheckProjectilePosition());
    }

    private void LateUpdate()
    {
        UnparentProjectile();
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

    private void UnparentProjectile()
    {
        if(this.transform.parent != null)
        {
            this.transform.parent = null;
        }
    }
}