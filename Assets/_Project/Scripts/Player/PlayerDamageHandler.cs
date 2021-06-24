using System;
using UnityEngine;

public sealed class PlayerDamageHandler : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Health System")]
    [SerializeField] private int _maxHealthAmount;
    private HealthSystem _playerHealthSystem;

    public event Action OnPlayerDied;

    public HealthSystem GetPlayerHealthSystem => _playerHealthSystem;

    private void Awake()
    {
        _playerHealthSystem = new HealthSystem(_maxHealthAmount);
        CanvasAssets.instance.GetHealthBarUI.Initialize(_playerHealthSystem);
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
            OnPlayerDied?.Invoke();
        }
    }
}