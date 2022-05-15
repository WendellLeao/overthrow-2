using _Project.Scripts.Events.ScriptableObject;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Player.PlayerHealthUI
{
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
}
