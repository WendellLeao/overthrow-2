using UnityEngine;

public sealed class PlayerDamageHandler : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Health System")]
    [SerializeField] private int _maxHealthAmount;

    [SerializeField] private HealthBarUI _healthBarUI;

    [Header("Listening on channel")]
    [SerializeField] private GameEvent _playerDeathEvent;
    
    private HealthSystem _playerHealthSystem;

    public HealthSystem GetPlayerHealthSystem => _playerHealthSystem;

    private void Awake()
    {
        _playerHealthSystem = new HealthSystem(_maxHealthAmount);
        _healthBarUI.Initialize(_playerHealthSystem);
    }

    private void OnEnable()
    {
        _playerHealthSystem.OnHealthChanged += OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void OnDisable()
    {
        _playerHealthSystem.OnHealthChanged -= OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void OnHealthChanged_CheckIfPlayerIsDead()
    {
        if(_playerHealthSystem.GetCurrentHealthAmount <= 0)
        {
            _playerDeathEvent.OnEventRaised?.Invoke();
        }
    }
}