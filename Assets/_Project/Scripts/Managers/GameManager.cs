using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _gameOverPanelObject;
    [SerializeField] private GameObject _winPanelObject;

    [Header("Invoking events")]
    [SerializeField] private GameEvent _gameStateChangeEvent;
    
    [Header("Listening to events")]
    [SerializeField] private GameEvent _playerDeathEvent;
    [SerializeField] private GameEvent _levelCompleteEvent;
    
    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    private void Awake()
    {
        _gameStateScriptableObject.CurrentGameState = GameState.PLAYING;
        
        ResumeGame();
    }

    private void OnEnable()
    {
        _levelCompleteEvent.OnEventRaised += OnPlayerIsAtLastTarget_LevelComplete;
        _playerDeathEvent.OnEventRaised += OnPlayerDied_LoseGame;
    }

    private void OnDisable()
    {
        _levelCompleteEvent.OnEventRaised -= OnPlayerIsAtLastTarget_LevelComplete;
        _playerDeathEvent.OnEventRaised -= OnPlayerDied_LoseGame;
    }

    private void OnPlayerIsAtLastTarget_LevelComplete()
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

        _gameStateChangeEvent.OnEventRaised?.Invoke();
    }
}