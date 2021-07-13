using UnityEngine;
using UnityEngine.UI;

public sealed class PauseGameHandler : MonoBehaviour
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
    
    private bool _canPauseGame = false;

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
        _globalGameEvents.OnGameStateChanged += OnGameStateChanged_CheckIfCanPause;
        
        _localGameEvents.OnReadPlayerInputs += OnGamePaused_HandlePauseGame;

        _resumeGameButton.onClick.AddListener(HidePausePanel);
        
        _restartGameButton.onClick.AddListener(SceneHandler.ReloadScene);
        _mainMenuButton.onClick.AddListener(SceneHandler.BackToMainMenu);
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnGameStateChanged -= OnGameStateChanged_CheckIfCanPause;
        
        _localGameEvents.OnReadPlayerInputs -= OnGamePaused_HandlePauseGame;

        _resumeGameButton.onClick.RemoveAllListeners();
        _restartGameButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnGameStateChanged_CheckIfCanPause(GameState gameState)
    {
        // if(gameState == GameState.PLAYING || gameState == GameState.PAUSED)
        // {
        //     _localGameEvents.OnReadPlayerInputs += OnGamePaused_HandlePauseGame;
        // }
        // else if(gameState == GameState.WIN || gameState == GameState.LOSE)
        // {
        //     Debug.Log("desinscreveu :(");
        //     _localGameEvents.OnReadPlayerInputs -= OnGamePaused_HandlePauseGame;
        // }
    }
    
    private void OnGamePaused_HandlePauseGame(PlayerInputData playerInputData)
    {
        if (playerInputData.PressPause)
        {
            _canPauseGame = !_canPauseGame;
                
            if (_canPauseGame)
            {
                ShowPausePanel();
            }
            else
            {
                HidePausePanel();
            }
        }
    }

    private void HidePausePanel()
    {
        ResumeGame();

        _canPauseGame = false;

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
}