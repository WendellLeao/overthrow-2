using UnityEngine;
using UnityEngine.UI;

public sealed class GameOverHandler : MonoBehaviour
{
    [Header("Panels UI")]
    [SerializeField] private GameObject _gameOverPanelObject;

    [Header("Buttons UI")]
    [SerializeField] private Button _restartGameButton;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;

    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;
    
    private SceneHandler _sceneHandler = new SceneHandler();

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

        _restartGameButton.onClick.AddListener(_sceneHandler.ReloadScene);
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnPlayerDied -= OnPlayerDied_LoseGame;

        _restartGameButton.onClick.RemoveAllListeners();
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
        _gameStateScriptableObject._currentGameState = newGameState;

        _globalGameEvents.OnGameStateChanged?.Invoke();
    }
}