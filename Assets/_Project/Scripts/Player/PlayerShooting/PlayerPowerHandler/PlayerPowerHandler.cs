using UnityEngine;

public sealed class PlayerPowerHandler : MonoBehaviour
{
    [Header("Power")]
    [SerializeField] private int _maxPowerAmount;
    
    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvent;

    private int _currentPowerAmount;

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
        SetCurrentPowerAmount(0);
    }

    private void SubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs += OnPlayerShotBomb_PerformShootingBomb;
        _localGameEvent.OnLaserCollide += IncreasePowerAmount;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs -= OnPlayerShotBomb_PerformShootingBomb;
        _localGameEvent.OnLaserCollide -= IncreasePowerAmount;
    }

    private void SetCurrentPowerAmount(int powerAmount)
    {
        _currentPowerAmount = powerAmount;

        _localGameEvent.OnPowerChanged?.Invoke(_currentPowerAmount, _maxPowerAmount);
    }

    private void OnPlayerShotBomb_PerformShootingBomb(PlayerInputData playerInputData)
    {
        if(playerInputData.IsShootingBomb && !playerInputData.IsShooting && _currentPowerAmount >= _maxPowerAmount)
        {
            _localGameEvent.OnPlayerBombShot?.Invoke();

            SetCurrentPowerAmount(0);
        }
    }

    private void IncreasePowerAmount()
    {
        _currentPowerAmount += 5;

        _localGameEvent.OnPowerChanged?.Invoke(_currentPowerAmount, _maxPowerAmount);
    }
}