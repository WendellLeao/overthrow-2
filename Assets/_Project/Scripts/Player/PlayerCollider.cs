using UnityEngine;

public sealed class PlayerCollider : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IObstacle>(out IObstacle obstacle))
        {
            if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
            {
                if(deactivatableObject.IsActivated)
                {
                    deactivatableObject.IsActivated = false;
                    
                    _playerController.GetPlayerDamageHandler().DamagePlayer(obstacle.GetDamageToPlayerAmount());
                }
            }
            else if(other.TryGetComponent<Smasher>(out Smasher smasher))
            {
                _playerController.GetPlayerDamageHandler().DamagePlayer(obstacle.GetDamageToPlayerAmount());
            }
        }
    }
}
