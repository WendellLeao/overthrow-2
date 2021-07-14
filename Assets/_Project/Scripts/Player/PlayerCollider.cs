using UnityEngine;

public sealed class PlayerCollider : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
        {
            if(deactivatableObject.GetIsActivated && other.TryGetComponent<IObstacle>(out IObstacle obstacle))
            {
                deactivatableObject.SetIsActivated(false);
                _playerHealthSystem.Damage(50);
            }
        }

        if(other.TryGetComponent<Smasher>(out Smasher smasher))
        {
            _playerHealthSystem.Damage(200);
        }
    }
}