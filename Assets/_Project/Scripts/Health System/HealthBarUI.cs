using UnityEngine;
using UnityEngine.UI;

public sealed class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage;
    private HealthSystem _healthSystem;

    public void Initialize(HealthSystem healthSystem)
    {
        _healthSystem = healthSystem;
    }

    private void Start()
    {
        _healthSystem.OnHealthChanged += OnHealthChanged_UpdateHealthBar;
    }

    private void OnEnable()
    {
        //_healthSystem.OnHealthChanged += OnHealthChanged_UpdateHealthBar; NullReferenceException
    }

    private void OnDisable()
    {
        _healthSystem.OnHealthChanged -= OnHealthChanged_UpdateHealthBar;
    }

    private void OnHealthChanged_UpdateHealthBar()
    {
        float healthPercent = (float)_healthSystem.GetCurrentHealthAmount / _healthSystem.GetMaxHealthAmount;
        _healthBarImage.fillAmount = healthPercent;
    }
}