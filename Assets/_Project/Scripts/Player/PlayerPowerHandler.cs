using UnityEngine;

public sealed class PlayerPowerHandler : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvent;

    [Header("Power")]
    [SerializeField] private int _maxPowerAmount;
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
        SetCurrentPowerAmount(_maxPowerAmount);
    }

    private void SubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs += OnPlayerShotBomb_PerformShootingBomb;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs -= OnPlayerShotBomb_PerformShootingBomb;
    }

    private void SetCurrentPowerAmount(int powerAmount)
    {
        _currentPowerAmount = powerAmount;
    }

    private void OnPlayerShotBomb_PerformShootingBomb(PlayerInputData playerInputData)
    {
        if(playerInputData.IsShootingBomb && _currentPowerAmount >= _maxPowerAmount)
        {
            _localGameEvent.OnPlayerBombShot.Invoke();

            SetCurrentPowerAmount(0);
        }
    }
}