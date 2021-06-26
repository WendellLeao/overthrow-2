using UnityEngine;
using UnityEngine.UI;

public sealed class HealthBarUI : MonoBehaviour
{
    [Header("Player Health System")]
    [SerializeField] private HealthSystem _healthSystem;

    [Header("UI")]
    [SerializeField] private Image _healthBarImage;

    [Header("Listening to events")]
    [SerializeField] private GameEvent _healthChangeEvent;

    private void OnEnable()
    {
        _healthChangeEvent.OnEventRaised += OnHealthChanged_UpdateHealthBar;
    }

    private void OnDisable()
    {
        _healthChangeEvent.OnEventRaised -= OnHealthChanged_UpdateHealthBar;
    }

    private void OnHealthChanged_UpdateHealthBar()
    {
        float healthPercent = (float)_healthSystem.GetCurrentHealthAmount / _healthSystem.GetMaxHealthAmount;
        _healthBarImage.fillAmount = healthPercent;
    }
}