using System;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    public event Action OnGameStateChanged;
    
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;
    
    private GameState _currentGameState;

    public GameState GetCurrentGameState => _currentGameState;

    public void OnGamePaused_HandlePauseGame()
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

    private void Awake()
    {
        _currentGameState = GameState.PLAYING;
        
        ResumeGame();
    }

    private void OnEnable()
    {
        _playerController.GetWayPointSystem.OnPlayerIsAtLastTarget += OnPlayerIsAtLastTarget_LevelComplete;
        _playerController.GetPlayerDamageHandler.OnPlayerDied += OnPlayerDied_LoseGame;
        _playerController.GetPlayerInput.OnGamePaused += OnGamePaused_HandlePauseGame;
    }

    private void OnDisable()
    {
        _playerController.GetWayPointSystem.OnPlayerIsAtLastTarget -= OnPlayerIsAtLastTarget_LevelComplete;
        _playerController.GetPlayerDamageHandler.OnPlayerDied -= OnPlayerDied_LoseGame;
        _playerController.GetPlayerInput.OnGamePaused -= OnGamePaused_HandlePauseGame;
    }

    private void ShowPausePanel()
    {
        StopGame();
        
        SetGameState(GameState.PAUSED);

        CanvasAssets.instance.GetPausePanelObject.SetActive(true);
    }

    private void HidePausePanel()
    {
        ResumeGame();

        SetGameState(GameState.PLAYING);

        CanvasAssets.instance.GetPausePanelObject.SetActive(false);
    }

    private bool IsPaused()
    {
        return Time.timeScale == 0f;
    }

    private void OnPlayerIsAtLastTarget_LevelComplete()
    {
        StopGame();

        SetGameState(GameState.WIN);

        CanvasAssets.instance.GetWinPanelObject.SetActive(true);
    }

    private void OnPlayerDied_LoseGame()
    {
        StopGame();

        SetGameState(GameState.LOSE);

        CanvasAssets.instance.GetGameOverPanelObject.SetActive(true);
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
        _currentGameState = newGameState;

        OnGameStateChanged?.Invoke();
    }
}