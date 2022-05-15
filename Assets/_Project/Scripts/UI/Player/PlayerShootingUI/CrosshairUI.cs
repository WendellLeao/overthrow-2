using _Project.Scripts.Enums.Managers.GameManager;
using _Project.Scripts.Events.ScriptableObject;
using UnityEngine;

namespace _Project.Scripts.UI.Player.PlayerShootingUI
{
    public sealed class CrosshairUI : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject _crosshairObject;
    
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
            _globalGameEvents.OnGameStateChanged += OnGameStateChanged_CheckIfCanDisableCrosshair;
        }

        private void UnsubscribeEvents()
        {
            _globalGameEvents.OnGameStateChanged -= OnGameStateChanged_CheckIfCanDisableCrosshair;
        }
    
        private void OnGameStateChanged_CheckIfCanDisableCrosshair(GameState gameState)
        {
            _crosshairObject.SetActive(gameState == GameState.PLAYING);
        }
    }
}
