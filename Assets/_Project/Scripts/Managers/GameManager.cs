using System;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    public event Action OnGameStateChanged;

    [Header("Panels")]
    [SerializeField] private GameObject _gameOverPanelObject;
    [SerializeField] private GameObject _winPanelObject;
    
    [Header("Listening on channels")]
    [SerializeField] private GameEvent _playerDeathEvent;
    [SerializeField] private GameEvent _pauseGameEvent;
    [SerializeField] private GameEvent _levelCompleteEvent;
    
    private GameState _currentGameState;

    public GameState GetCurrentGameState => _currentGameState;

    private void Awake()
    {
        _currentGameState = GameState.PLAYING;
        
        ResumeGame();
    }

    private void OnEnable()
    {
        _levelCompleteEvent.OnEventRaised += OnPlayerIsAtLastTarget_LevelComplete;
        //_pauseGameEvent.OnEventRaised += OnGamePaused_HandlePauseGame;
        _playerDeathEvent.OnEventRaised += OnPlayerDied_LoseGame;
    }

    private void OnDisable()
    {
        _levelCompleteEvent.OnEventRaised -= OnPlayerIsAtLastTarget_LevelComplete;
        //_pauseGameEvent.OnEventRaised -= OnGamePaused_HandlePauseGame;
        _playerDeathEvent.OnEventRaised -= OnPlayerDied_LoseGame;
    }

    private void OnPlayerIsAtLastTarget_LevelComplete()
    {
        StopGame();

        //SetGameState(GameState.WIN);

        _winPanelObject.SetActive(true);
    }

    private void OnPlayerDied_LoseGame()
    {
        StopGame();

        //SetGameState(GameState.LOSE);

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
}