using UnityEngine;

public sealed class PlayerCollider : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
        {
            if(deactivatableObject.IsActivated && other.TryGetComponent<IObstacle>(out IObstacle obstacle))
            {
                deactivatableObject.IsActivated = false;
                _playerHealthSystem.Damage(50);
            }
        }

        if(other.TryGetComponent<Smasher>(out Smasher smasher))
        {
            _playerHealthSystem.Damage(200);
        }
    }
}
