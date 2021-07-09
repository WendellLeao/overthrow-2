using UnityEngine;
using UnityEngine.UI;

public sealed class PauseMenuHandler : MonoBehaviour
{
    [Header("Panels UI")]
    [SerializeField] private GameObject _pausePanelObject;

    [Header("Buttons UI")]
    [SerializeField] private Button _restartGameButton; 
    [SerializeField] private Button _resumeGameButton; 
    [SerializeField] private Button _mainMenuButton; 

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    [SerializeField] private LocalGameEvents _localGameEvents;
    
    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableObject _gameStateScriptableObject;

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
        // _globalGameEvents.OnGameStateChanged += OnGameStateChanged_CheckIfCanPause;
        
        _localGameEvents.OnReadPlayerInputs += OnGamePaused_HandlePauseGame;

        _resumeGameButton.onClick.AddListener(HidePausePanel);
        
        _restartGameButton.onClick.AddListener(_sceneHandler.ReloadScene);
        _mainMenuButton.onClick.AddListener(_sceneHandler.BackToMainMenu);
    }

    private void UnsubscribeEvents()
    {
        // _globalGameEvents.OnGameStateChanged -= OnGameStateChanged_CheckIfCanPause;
        
        _localGameEvents.OnReadPlayerInputs -= OnGamePaused_HandlePauseGame;

        _resumeGameButton.onClick.RemoveAllListeners();
        _restartGameButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnGameStateChanged_CheckIfCanPause(GameState gameState)
    {
        if(gameState != GameState.LOSE && gameState != GameState.WIN)
        {
            _localGameEvents.OnReadPlayerInputs += OnGamePaused_HandlePauseGame;
        }
        else
        {
            _localGameEvents.OnReadPlayerInputs -= OnGamePaused_HandlePauseGame;
        }
    }
    
    private void OnGamePaused_HandlePauseGame(PlayerInputData playerInputData)
    {
        if(_gameStateScriptableObject.CurrentGameState != GameState.LOSE 
        && _gameStateScriptableObject.CurrentGameState != GameState.WIN)///////////////////////////////
        {
            if(GameIsStopped() && !playerInputData.PressPause)
            {
                HidePausePanel();
            }
            else if (!GameIsStopped() && playerInputData.PressPause)
            {
                ShowPausePanel();
            }
        }
    }

    private void HidePausePanel()
    {
        ResumeGame();

        SetGameState(GameState.PLAYING);

        _pausePanelObject.SetActive(false);
    }

    private void ShowPausePanel()
    {
        StopGame();

        SetGameState(GameState.PAUSED);
        
        _pausePanelObject.SetActive(true);
    }
    
    private void ResumeGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
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

    private bool GameIsStopped()
    {
        return Time.timeScale == 0f;
    }
}