using UnityEngine.UI;
using UnityEngine;

public sealed class HealthBarUI : MonoBehaviour
{
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

    private void OnHealthChanged_UpdateHealthBar(int currentHealthAmount, int maxHealthAmount)
    {
        float healthPercent = (float)currentHealthAmount / maxHealthAmount;
        
        _healthBarImage.fillAmount = healthPercent;
    }
}
