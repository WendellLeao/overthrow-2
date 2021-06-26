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
    [SerializeField] private GameEvent _healthChangeEvent;

    public HealthSystem GetPlayerHealthSystem => _playerHealthSystem;

    private void OnEnable()
    {
        _healthChangeEvent.OnEventRaised += OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void OnDisable()
    {
        _healthChangeEvent.OnEventRaised -= OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void Start()
    {
        _playerHealthSystem.ResetCurrentHealthAmount();
    }

    private void OnHealthChanged_CheckIfPlayerIsDead()
    {
        if(_playerHealthSystem.GetCurrentHealthAmount <= 0)
        {
            _playerDeathEvent.OnEventRaised?.Invoke();
        }
    }
}