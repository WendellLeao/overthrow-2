using UnityEngine;

public sealed class PauseGameHandler : MonoBehaviour
{
    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    [Header("Invoking events")]
    [SerializeField] private GameEvent _gameStateChangeEvent;

    [Header("Listening to events")]
    [SerializeField] private GameEvent _pauseGameEvent;

    [Header("UI")]
    [SerializeField] private GameObject _pausePanelObject;
    
    public void HidePausePanel()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;

        SetGameState(GameState.PLAYING);

        _pausePanelObject.SetActive(false);
    }

    private void OnEnable()
    {
        _pauseGameEvent.OnEventRaised += OnGamePaused_HandlePauseGame;
    }

    private void OnDisable()
    {
        _pauseGameEvent.OnEventRaised -= OnGamePaused_HandlePauseGame;
    }

    private void OnGamePaused_HandlePauseGame()
    {
        if(CanPauseGame())
        {
            if (IsPaused())
            {
                HidePausePanel();
            }
            else
            {
                ShowPausePanel();
            }
        }
    }

    private void ShowPausePanel()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;

        SetGameState(GameState.PAUSED);
        
        _pausePanelObject.SetActive(true);
    }

    private void SetGameState(GameState newGameState)
    {
        _gameStateScriptableObject._currentGameState = newGameState;

        _gameStateChangeEvent.OnEventRaised?.Invoke();
    }

    private bool IsPaused()
    {
        return Time.timeScale == 0f;
    }

    private bool CanPauseGame()
    {
        return _gameStateScriptableObject.CurrentGameState == GameState.PLAYING 
        || _gameStateScriptableObject.CurrentGameState == GameState.PAUSED;
    }
}