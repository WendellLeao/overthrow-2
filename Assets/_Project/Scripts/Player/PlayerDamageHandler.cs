using UnityEngine;

public sealed class PlayerDamageHandler : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    [Header("Invoking events")]
    [SerializeField] private GameEvent _playerDeathEvent;

    [Header("Listening to events")]
    [SerializeField] private GameEventListener _healthChangeEvent;

    public HealthSystem GetPlayerHealthSystem => _playerHealthSystem;

    public void OnHealthChanged_CheckIfPlayerIsDead()
    {
        if(_playerHealthSystem.GetCurrentHealthAmount <= 0)
        {
            _playerDeathEvent.Raise();
        }
    }
    
    private void Start()
    {
        _playerHealthSystem.ResetCurrentHealthAmount();
    }
}