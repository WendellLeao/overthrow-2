using UnityEngine;

public sealed class PlayerDamageHandler : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    [SerializeField] private LocalGameEvents _localGameEvents;

    public HealthSystem GetPlayerHealthSystem => _playerHealthSystem;
    
    private void OnEnable()
    {
        _localGameEvents.OnHealthChanged += OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void OnDisable()
    {
        _localGameEvents.OnHealthChanged -= OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void Start()
    {
        _playerHealthSystem.ResetCurrentHealthAmount();
    }

    private void OnHealthChanged_CheckIfPlayerIsDead()
    {
        if(_playerHealthSystem.GetCurrentHealthAmount <= 0)
        {
            _globalGameEvents.OnPlayerDied?.Invoke();
        }
    }
}