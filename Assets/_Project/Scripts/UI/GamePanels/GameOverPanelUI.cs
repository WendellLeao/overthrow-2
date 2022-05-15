using _Project.Scripts.Events.ScriptableObject;
using _Project.Scripts.Managers.SceneManager;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.GamePanels
{
    public class GameOverPanelUI : MonoBehaviour
    {
        [Header("Panels UI")]
        [SerializeField] private GameObject _gameOverPanelObject;

        [Header("Buttons UI")]
        [SerializeField] private Button _restartGameButton;
        [SerializeField] private Button _mainMenuButton; 

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
            _globalGameEvents.OnPlayerDied += OnPlayerDied_ShowGameOverPanelUI;

            _restartGameButton.onClick.AddListener(SceneHandler.ReloadScene);
            _mainMenuButton.onClick.AddListener(SceneHandler.BackToMainMenu);
        }

        private void UnsubscribeEvents()
        {
            _globalGameEvents.OnPlayerDied -= OnPlayerDied_ShowGameOverPanelUI;

            _restartGameButton.onClick.RemoveAllListeners();
            _mainMenuButton.onClick.RemoveAllListeners();
        }

        private void OnPlayerDied_ShowGameOverPanelUI()
        {
            _gameOverPanelObject.SetActive(true);
        }
    }
}
