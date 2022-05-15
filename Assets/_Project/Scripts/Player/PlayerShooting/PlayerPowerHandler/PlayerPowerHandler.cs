using _Project.Scripts.Enums.Managers.GameManager;
using _Project.Scripts.Events.ScriptableObject;
using _Project.Scripts.Player.PlayerInput;
using UnityEngine;

namespace _Project.Scripts.Player.PlayerShooting.PlayerPowerHandler
{
    public sealed class PlayerPowerHandler : MonoBehaviour
    {
        [Header("Power")]
        [SerializeField] private int _maxPowerAmount;
    
        [Header("Game Events")]
        [SerializeField] private GlobalGameEvents _globalGameEvents;
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
            _globalGameEvents.OnGameStateChanged += OnGameStateChanged_CheckIfCanShoot;
        }

        private void UnsubscribeEvents()
        {
            _globalGameEvents.OnGameStateChanged -= OnGameStateChanged_CheckIfCanShoot;
        
            _localGameEvent.OnReadPlayerInputs -= OnPlayerShotBomb_PerformBombShooting;
            _localGameEvent.OnLaserCollide -= IncreasePowerAmount;
        }
    
        private void OnGameStateChanged_CheckIfCanShoot(GameState gameState)
        {
            if(gameState == GameState.PLAYING)
            {
                _localGameEvent.OnReadPlayerInputs += OnPlayerShotBomb_PerformBombShooting;
                _localGameEvent.OnLaserCollide += IncreasePowerAmount;
            }
            else
            {
                _localGameEvent.OnReadPlayerInputs -= OnPlayerShotBomb_PerformBombShooting;
                _localGameEvent.OnLaserCollide -= IncreasePowerAmount;
            }
        }
    
        private void OnPlayerShotBomb_PerformBombShooting(PlayerInputData playerInputData)
        {
            if(playerInputData.IsShootingBomb && !playerInputData.IsShooting && _currentPowerAmount >= _maxPowerAmount)
            {
                _localGameEvent.OnPlayerShotBomb?.Invoke();

                SetCurrentPowerAmount(0);
            }
        }

        private void IncreasePowerAmount()
        {
            if(_currentPowerAmount < _maxPowerAmount)
            {
                _currentPowerAmount += 5;
            }
            else
            {
                _currentPowerAmount = _maxPowerAmount;
            }

            _localGameEvent.OnPowerChanged?.Invoke(_currentPowerAmount, _maxPowerAmount);
        }
    
        private void SetCurrentPowerAmount(int powerAmount)
        {
            _currentPowerAmount = powerAmount;

            _localGameEvent.OnPowerChanged?.Invoke(_currentPowerAmount, _maxPowerAmount);
        }
    }
}
