using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    [Header("Player Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    private void OnTriggerEnter(Collider other)
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
            else
            {
                destructibleObject.DestroyObject();
            }
        }
    }
}