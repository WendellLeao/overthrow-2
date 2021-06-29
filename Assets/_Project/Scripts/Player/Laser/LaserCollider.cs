using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    [Header("Player Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DestructibleObject>(out DestructibleObject destructibleObject))
        {
            if(!destructibleObject.GetIsEnabled)
            {
                destructibleObject.DestroyObject();
            }
        }
    }
}