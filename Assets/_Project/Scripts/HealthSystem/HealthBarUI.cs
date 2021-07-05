using UnityEngine;
using UnityEngine.UI;

public sealed class HealthBarUI : MonoBehaviour
{
    [Header("Player Health System")]
    [SerializeField] private HealthSystem _healthSystem;

    [Header("UI")]
    [SerializeField] private Image _healthBarImage;

    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvent;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _localGameEvent.OnHealthChanged += OnHealthChanged_UpdateHealthBar;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvent.OnHealthChanged -= OnHealthChanged_UpdateHealthBar;
    }

    private void OnHealthChanged_UpdateHealthBar()
    {
        float healthPercent = (float)_healthSystem.GetCurrentHealthAmount / _healthSystem.GetMaxHealthAmount;
        _healthBarImage.fillAmount = healthPercent;
    }
}