using UnityEngine;

public sealed class PlayerCollider : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DestructibleObject>(out DestructibleObject destructibleObject))
        {
            if(destructibleObject.GetIsEnabled)
            {
                if(other.TryGetComponent<Cube>(out Cube cube))
                {
                    _playerHealthSystem.Damage(20);
                }
            }
        }

        if(other.TryGetComponent<Smasher>(out Smasher smasher))
        {
            _playerHealthSystem.Damage(200);
        }
    }
}