using UnityEngine;

public sealed class PlayerCollider : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DestructibleObject>(out DestructibleObject destructibleObject))
        {
            if(destructibleObject.GetIsEnabled && other.TryGetComponent<BarricadeCube>(out BarricadeCube cubeBarricade))
            {
                _playerHealthSystem.Damage(20);
            }
        }

        if(other.TryGetComponent<Smasher>(out Smasher smasher))
        {
            _playerHealthSystem.Damage(200);
        }
    }
}