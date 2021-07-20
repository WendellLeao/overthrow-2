using UnityEngine;
using UnityEngine.UI;

public sealed class GameOverHandler : MonoBehaviour
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
        _globalGameEvents.OnPlayerDied += OnPlayerDied_LoseGame;

        _restartGameButton.onClick.AddListener(SceneHandler.ReloadScene);
        _mainMenuButton.onClick.AddListener(SceneHandler.BackToMainMenu);
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnPlayerDied -= OnPlayerDied_LoseGame;

        _restartGameButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnPlayerDied_LoseGame()
    {
        StopGame();

        SetGameState(GameState.LOSE);

        _gameOverPanelObject.SetActive(true);
    }

    private void StopGame()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
    }

    private void SetGameState(GameState newGameState)
    {
        _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
    }
}