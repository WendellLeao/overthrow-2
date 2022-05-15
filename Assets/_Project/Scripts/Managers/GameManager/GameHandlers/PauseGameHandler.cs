using _Project.Scripts.Enums.Managers.GameManager;
using _Project.Scripts.Events.ScriptableObject;
using _Project.Scripts.Player.PlayerInput;
using UnityEngine;

namespace _Project.Scripts.Managers.GameManager.GameHandlers
{
    public sealed class PauseGameHandler : MonoBehaviour
    {
        [Header("Game Events")]
        [SerializeField] private GlobalGameEvents _globalGameEvents;
        [SerializeField] private LocalGameEvents _localGameEvents;

        private bool _canPauseGame = false;

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
            _globalGameEvents.OnGameStateChanged += OnGameStateChanged_CheckIfCanPause;
        
            _globalGameEvents.OnGameIsPaused += OnGameIsPaused_HandlePauseGame;

            _localGameEvents.OnReadPlayerInputs += OnPressPause_HandlePauseGame;
        }

        private void UnsubscribeEvents()
        {
            _globalGameEvents.OnGameStateChanged -= OnGameStateChanged_CheckIfCanPause;
        
            _globalGameEvents.OnGameIsPaused -= OnGameIsPaused_HandlePauseGame;
        
            _localGameEvents.OnReadPlayerInputs -= OnPressPause_HandlePauseGame;
        }

        private void OnGameStateChanged_CheckIfCanPause(GameState gameState)
        {
            if(gameState == GameState.LOSE || gameState == GameState.WIN)
            {
                _globalGameEvents.OnGameIsPaused -= OnGameIsPaused_HandlePauseGame;
            
                _localGameEvents.OnReadPlayerInputs -= OnPressPause_HandlePauseGame;
            }
        }
    
        private void OnPressPause_HandlePauseGame(PlayerInputData playerInputData)
        {
            if (playerInputData.PressPause)
            {
                _canPauseGame = !_canPauseGame;
                
                OnGameIsPaused_HandlePauseGame(_canPauseGame);
            
                _globalGameEvents.OnGameIsPaused?.Invoke(_canPauseGame);
            }
        }
    
        private void OnGameIsPaused_HandlePauseGame(bool canPauseGame)
        {
            if (canPauseGame)
            {
                StopGame();
            }
            else
            {
                ResumeGame();
            }
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.Locked;

            _canPauseGame = false;

            ChangeGameState(GameState.PLAYING);
        }

        private void StopGame()
        {
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;

            ChangeGameState(GameState.PAUSED);
        }

        private void ChangeGameState(GameState newGameState)
        {
            _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
        }
    }
}
