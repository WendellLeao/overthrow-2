using _Project.Scripts.Enums.Managers.GameManager;
using _Project.Scripts.Enums.Managers.SoundManager;
using _Project.Scripts.Events.ScriptableObject;
using UnityEngine;

namespace _Project.Scripts.Managers.GameManager.GameHandlers
{
    public sealed class GameOverHandler : MonoBehaviour
    {
        [Header("Game Events")]
        [SerializeField] private GlobalGameEvents _globalGameEvents;

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
            _globalGameEvents.OnPlayerDied += OnPlayerDied_LoseGame;
        }

        private void UnsubscribeEvents()
        {
            _globalGameEvents.OnPlayerDied -= OnPlayerDied_LoseGame;
        }

        private void OnPlayerDied_LoseGame()
        {
            StopGame();

            ChangeGameState(GameState.LOSE);
        
            SoundManager.SoundManager.instance.PlaySound2D(Sound.GAME_OVER);
        }

        private void StopGame()
        {
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
        }

        private void ChangeGameState(GameState newGameState)
        {
            _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
        }
    }
}
