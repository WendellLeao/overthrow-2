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
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void Awake()
    {
        _currentGameState = GameState.PLAYING;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        Time.timeScale = 1f;
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

    void Update()
    {
        Debug.Log(_currentGameState);
    }

    private void PauseGame()
    {
        SetGameState(GameState.PAUSED);

        CanvasAssets.instance.GetPausePanelObject.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;

        _currentGameState = GameState.PLAYING;

        OnGameStateChanged?.Invoke();

        Cursor.lockState = CursorLockMode.Locked;

        CanvasAssets.instance.GetPausePanelObject.SetActive(false);
    }

    private bool IsPaused()
    {
        return Time.timeScale == 0f;
    }

    private void OnPlayerIsAtLastTarget_LevelComplete()
    {
        SetGameState(GameState.WIN);

        CanvasAssets.instance.GetWinPanelObject.SetActive(true);
    }

    private void OnPlayerDied_LoseGame()
    {
        SetGameState(GameState.LOSE);

        CanvasAssets.instance.GetGameOverPanelObject.SetActive(true);
    }

    private void SetGameState(GameState newGameState)
    {
        Time.timeScale = 0f;

        _currentGameState = newGameState;

        OnGameStateChanged?.Invoke();

        Cursor.lockState = CursorLockMode.None;
    }
}
