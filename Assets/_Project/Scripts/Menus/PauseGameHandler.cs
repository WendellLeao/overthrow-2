using UnityEngine;
using UnityEngine.UI;

public sealed class PauseGameHandler : MonoBehaviour
{
    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    [SerializeField] private LocalGameEvents _localGameEvent;

    [Header("Panels UI")]
    [SerializeField] private GameObject _pausePanelObject;

    [Header("Buttons UI")]
    [SerializeField] private Button _restartGameButton; 
    [SerializeField] private Button _resumeGameButton; 

    [SerializeField] private SceneHandler _sceneHandler = new SceneHandler();

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
        _localGameEvent.OnReadPlayerInputs += OnGamePaused_HandlePauseGame;

        _resumeGameButton.onClick.AddListener(HidePausePanel);
        _restartGameButton.onClick.AddListener(_sceneHandler.ReloadScene);
    }

    private void UnsubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs -= OnGamePaused_HandlePauseGame;

        _resumeGameButton.onClick.RemoveAllListeners();
        _restartGameButton.onClick.RemoveAllListeners();
    }
    
    private void OnGamePaused_HandlePauseGame(PlayerInputData playerInputData)
    {
        if(CanPauseGame() && playerInputData.GameIsPaused)
        {
            if(IsPaused())
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