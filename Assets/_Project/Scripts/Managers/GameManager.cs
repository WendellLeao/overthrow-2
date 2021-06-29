using UnityEngine;
using UnityEngine.UI;

public sealed class GameManager : MonoBehaviour
{
    [Header("Panels UI")]
    [SerializeField] private GameObject _gameOverPanelObject;
    [SerializeField] private GameObject _winPanelObject;

    [Header("Buttons UI")]
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _continueButton;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    
    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;
    private SceneHandler _sceneHandler = new SceneHandler();

    private void Awake()
    {
        ResumeGame();

        SetGameState(GameState.PLAYING);
    }

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
        _globalGameEvents.OnLevelCompleted += OnLevelCompleted_LevelComplete;
        _globalGameEvents.OnPlayerDied += OnPlayerDied_LoseGame;

        _restartGameButton.onClick.AddListener(_sceneHandler.ReloadScene);
        _continueButton.onClick.AddListener(_sceneHandler.LoadNextScene);
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnLevelCompleted -= OnLevelCompleted_LevelComplete;
        _globalGameEvents.OnPlayerDied -= OnPlayerDied_LoseGame;

        _restartGameButton.onClick.RemoveAllListeners();
        _continueButton.onClick.RemoveAllListeners();
    }

    private void OnLevelCompleted_LevelComplete()
    {
        StopGame();

        SetGameState(GameState.WIN);

        _winPanelObject.SetActive(true);
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

    private void ResumeGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetGameState(GameState newGameState)
    {
        _gameStateScriptableObject._currentGameState = newGameState;

        _globalGameEvents.OnGameStateChanged?.Invoke();
    }
}