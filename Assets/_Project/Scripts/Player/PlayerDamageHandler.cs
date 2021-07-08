using UnityEngine;

public sealed class PlayerDamageHandler : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    [SerializeField] private LocalGameEvents _localGameEvents;
    
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

    private void OnHealthChanged_CheckIfPlayerIsDead(int currentHealthAmount, int maxHealthAmount)
    {
        if(currentHealthAmount <= 0)
        {
            _globalGameEvents.OnPlayerDied?.Invoke();
        }
    }
}