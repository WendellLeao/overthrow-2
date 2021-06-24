using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DestructibleObject>(out DestructibleObject destructibleObject))
        {
            if(destructibleObject.GetIsEnabled)
            {
                if(other.TryGetComponent<Cube>(out Cube cube))
                {
                    _playerController.GetPlayerDamageHandler.GetPlayerHealthSystem.Damage(20);
                }
            }
            else
            {
                destructibleObject.DestroyObject();
            }
        }
    }
}