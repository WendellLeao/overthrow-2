using _Project.Scripts.Events.ScriptableObject;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Player.PlayerShooting.PlayerPowerHandler
{
    public sealed class PlayerPowerUI : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Image _powerBarImage;

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
            _localGameEvent.OnPowerChanged += OnPowerChanged_UpdatePowerAmountUI;
        }

        private void UnsubscribeEvents()
        {
            _localGameEvent.OnPowerChanged -= OnPowerChanged_UpdatePowerAmountUI;
        }

        private void OnPowerChanged_UpdatePowerAmountUI(int currentPowerAmount, int maxPowerAmount)
        {
            float healthPercent = (float)currentPowerAmount / maxPowerAmount;
        
            _powerBarImage.fillAmount = healthPercent;
        }
    }
}
