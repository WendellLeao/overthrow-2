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
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void Start()
    {
        ResetCurrentHealthAmount();
    }

    private void SubscribeEvents()
    {
        _localGameEvents.OnHealthChanged += OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvents.OnHealthChanged -= OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void ResetCurrentHealthAmount()
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