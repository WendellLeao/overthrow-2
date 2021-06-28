using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _gameOverPanelObject;
    [SerializeField] private GameObject _winPanelObject;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    
    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    private void Awake()
    {
        _gameStateScriptableObject.CurrentGameState = GameState.PLAYING;

        ResumeGame();
    }

    private void OnEnable()
    {
        _globalGameEvents.OnLevelCompleted += OnLevelCompleted_LevelComplete;
        _globalGameEvents.OnPlayerDied += OnPlayerDied_LoseGame;
    }

    private void OnDisable()
    {
        _globalGameEvents.OnLevelCompleted -= OnLevelCompleted_LevelComplete;
        _globalGameEvents.OnPlayerDied -= OnPlayerDied_LoseGame;
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