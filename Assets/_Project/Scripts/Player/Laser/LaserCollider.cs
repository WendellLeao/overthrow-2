using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    [Header("Player Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
        {
            if(!deactivatableObject.GetIsActivated)
            {
                deactivatableObject.DeactivateObject();
            }
        }
    }
}