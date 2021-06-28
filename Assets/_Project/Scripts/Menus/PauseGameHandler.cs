using UnityEngine;

public sealed class PauseGameHandler : MonoBehaviour
{
    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    [SerializeField] private LocalGameEvents _localGameEvent;

    [Header("UI")]
    [SerializeField] private GameObject _pausePanelObject;

    private void OnEnable()
    {
        //_globalGameEvents.OnGamePaused += OnGamePaused_HandlePauseGame;
        _localGameEvent.OnReadPlayerInputs += OnGamePaused_HandlePauseGame;
    }

    private void OnDisable()
    {
        //_globalGameEvents.OnGamePaused -= OnGamePaused_HandlePauseGame;
        _localGameEvent.OnReadPlayerInputs -= OnGamePaused_HandlePauseGame;
    }
    
    private void OnGamePaused_HandlePauseGame(PlayerInputData playerInputData)
    {
        if(CanPauseGame())
        {
            if (playerInputData.GameIsPaused)//IsPaused()
            {
                HidePausePanel();
            }
            else
            {
                ShowPausePanel();
            }
        }
    }

    private void HidePausePanel()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;

        SetGameState(GameState.PLAYING);

        _pausePanelObject.SetActive(false);
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

        _globalGameEvents.OnGameStateChanged?.Invoke();
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