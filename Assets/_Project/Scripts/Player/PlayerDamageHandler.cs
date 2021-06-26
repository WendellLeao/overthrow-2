using UnityEngine;

public sealed class PlayerDamageHandler : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    [Header("Invoking events")]
    [SerializeField] private VoidEventChannel _playerDeathEvent;

    public HealthSystem GetPlayerHealthSystem => _playerHealthSystem;

    public void CheckIfPlayerIsDead()
    {
        if(_playerHealthSystem.GetCurrentHealthAmount <= 0)
        {
            _playerDeathEvent.RaiseEvent();
        }
    }
    
    private void Start()
    {
        _playerHealthSystem.ResetCurrentHealthAmount();
    }
}