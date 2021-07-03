using UnityEngine;

public sealed class PlayerCollider : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
        {
            if(deactivatableObject.GetIsActivated && other.TryGetComponent<BarricadeCube>(out BarricadeCube barricadeCube))
            {
                _playerHealthSystem.Damage(35);
            }
        }

        if(other.TryGetComponent<Smasher>(out Smasher smasher))
        {
            _playerHealthSystem.Damage(200);
        }
    }
}