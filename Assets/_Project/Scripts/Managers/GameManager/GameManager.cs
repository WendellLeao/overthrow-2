using _Project.Scripts.Enums.Managers.GameManager;
using _Project.Scripts.Events.ScriptableObject;
using UnityEngine;

namespace _Project.Scripts.Managers.GameManager
{
    public sealed class GameManager : MonoBehaviour
    {
        [Header("Game Events")]
        [SerializeField] private GlobalGameEvents _globalGameEvents;

        private void Start()
        {
            ResumeGame();

            //SoundManager.instance.PlaySound2D(Sound.GAME_THEME);
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.Locked;
        
            ChangeSetGameState(GameState.PLAYING);
        }

        private void ChangeSetGameState(GameState newGameState)
        {
            _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
        }
    }
}
