using UnityEngine.UI;
using UnityEngine;

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
        _localGameEvent.OnPowerChanged += OnPlayerBombShot_UpdatePowerAmountUI;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvent.OnPowerChanged -= OnPlayerBombShot_UpdatePowerAmountUI;
    }

    public void OnPlayerBombShot_UpdatePowerAmountUI(int currentPowerAmount, int maxPowerAmount)
    {
        float healthPercent = (float)currentPowerAmount / maxPowerAmount;
        
        _powerBarImage.fillAmount = healthPercent;
    }
}